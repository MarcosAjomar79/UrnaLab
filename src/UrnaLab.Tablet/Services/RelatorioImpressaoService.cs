using System.Net;
using UrnaLab.Tablet.Models;
using System.Text;
using UrnaLab.Tablet.Properties.Models;


#if ANDROID
using Android.Content;
using Android.Print;
using Android.Webkit;
#endif

namespace UrnaLab.Tablet.Services
{
    public static class RelatorioImpressaoService
    {
#if ANDROID
        private static Android.Webkit.WebView? webViewImpressao;
#endif
        public static Task ImprimirVotosAsync(List<RelatorioVoto> votos)
        {
            var linhas = new StringBuilder();

            foreach (RelatorioVoto voto in votos)
            {
                linhas.AppendLine($"""
                <tr>
                    <td>{Codificar(voto.Ra)}</td>
                    <td>{Codificar(voto.AlunoNome)}</td>
                    <td>{Codificar(voto.Turma)}</td>
                    <td>{voto.NumeroChapa}</td>
                    <td>{Codificar(voto.ChapaNome)}</td>
                    <td>{voto.DataHora:dd/MM/yyyy HH:mm:ss}</td>
                </tr>
                """);
            }

            if (votos.Count == 0)
            {
                linhas.AppendLine("""
                <tr>
                    <td colspan="6">
                        Nenhum voto registrado.
                    </td>
                </tr>
                """);
            }

            string cabecalho = """
            <th>RA</th>
            <th>Aluno</th>
            <th>Turma</th>
            <th>Nº Chapa</th>
            <th>Chapa</th>
            <th>Data/Hora</th>
            """;

            string html = MontarDocumento(
                "Relatório Nominal de Votos",
                cabecalho,
                linhas.ToString()
            );

            return ImprimirHtmlAsync(
                "UrnaLab - Relatório de Votos",
                html
            );
        }
        public static Task ImprimirResumoAsync(List<ResumoChapa> resumo)
        {
            var linhas = new StringBuilder();
            foreach (ResumoChapa chapa in resumo)
            {
                linhas.AppendLine($"""
                <tr>
                    <td>{chapa.Numero}</td>
                    <td>{Codificar(chapa.Nome)}</td>
                    <td>{chapa.TotalVotos}</td>
                </tr>
                """);
            }
            if (resumo.Count == 0)
            {
                linhas.AppendLine("""
                <tr>
                    <td colspan="3">
                        Nenhuma chapa registrada.
                    </td>
                </tr>
                """);
            }

            string cabecalho = """
                <th>Número</th>
                <th>Chapa</th>
                <th>Total de Votos</th>
            """;

            string html = MontarDocumento(
                "Resumo por Chapa",
                cabecalho,
                linhas.ToString()
            );

            return ImprimirHtmlAsync(
                "UrnaLab - Resumo por Chapa",
                html
            );
        }

        private static string MontarDocumento(string titulo, string cabecalho, string linhas)
        {
            return $$"""
            <!DOCTYPE html>

            <html>

            <head>

                <meta charset="UTF-8">

                <style>

                    body {
                        font-family: sans-serif;
                        padding: 24px;
                        color: #202631;
                    }

                    h1 {
                        color: #0B1F5C;
                        margin-bottom: 4px;
                    }

                    .data {
                        color: #667085;
                        margin-bottom: 24px;
                    }

                    table {
                        width: 100%;
                        border-collapse: collapse;
                    }

                    th {
                        background-color: #F2F4F7;
                        font-weight: bold;
                    }

                    th,
                    td {
                        border: 1px solid #D0D5DD;
                        padding: 8px;
                        text-align: left;
                        font-size: 12px;
                    }

                </style>

            </head>

            <body>

                <h1>{{Codificar(titulo)}}</h1>

                <div class="data">
                    UrnaLab • Gerado em
                    {{DateTime.Now:dd/MM/yyyy HH:mm:ss}}
                </div>

                <table>

                    <thead>
                        <tr>
                            {{cabecalho}}
                        </tr>
                    </thead>

                    <tbody>
                        {{linhas}}
                    </tbody>

                </table>

            </body>

            </html>
            """;
        }

        private static string Codificar(string? texto)
        {
            return WebUtility.HtmlEncode(texto ?? string.Empty);
        }
        private static Task ImprimirHtmlAsync(string nomeDocumento, string html)
        {
#if ANDROID
            var conclusao = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var activity = Platform.CurrentActivity;

            if (activity is null)
            {
                conclusao.SetException(
                    new InvalidOperationException(
                        "Não foi possível acessar a Activity atual do Android."
                    )
                );

                return conclusao.Task;
            }
            MainThread.BeginInvokeOnMainThread(() =>
            {
                try
                {
                    webViewImpressao = new Android.Webkit.WebView(activity);

                    webViewImpressao.Settings.JavaScriptEnabled = false;

                    webViewImpressao.SetWebViewClient(new ClienteImpressao(
                            view =>
                            {
                                try
                                {
                                    var printManager = activity.GetSystemService(Context.PrintService) as PrintManager;

                                    if (printManager is null)
                                    {
                                        throw new InvalidOperationException(
                                            "O serviço de impressão do Android não está disponível."
                                        );
                                    }

                                    var adaptador = view.CreatePrintDocumentAdapter(nomeDocumento);

                                    printManager.Print(nomeDocumento, adaptador, new PrintAttributes.Builder().Build());

                                    conclusao.TrySetResult(true);
                                }
                                catch (Exception ex)
                                {
                                    conclusao.TrySetException(ex);
                                }
                            }
                        )
                    );

                    webViewImpressao.LoadDataWithBaseURL(
                        null,
                        html,
                        "text/html",
                        "UTF-8",
                        null
                    );
                }
                catch (Exception ex)
                {
                    conclusao.TrySetException(ex);
                }
            });

            return conclusao.Task;

        #else

            return Task.FromException(new PlatformNotSupportedException("A impressão está disponível apenas no Android.")
    );

#endif
        }
#if ANDROID
        private sealed class ClienteImpressao : WebViewClient
        {
            private readonly Action<Android.Webkit.WebView> aoCarregar;

            public ClienteImpressao(Action<Android.Webkit.WebView> aoCarregar)
            {
                this.aoCarregar = aoCarregar;
            }

            public override void OnPageFinished(Android.Webkit.WebView? view, string? url)
            {
                base.OnPageFinished(view, url);

                if (view is not null)
                {
                    aoCarregar(view);
                }
            }
        }

#endif
    }
}