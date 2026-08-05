# Manual de Uso do UrnaLab

## 1. Objetivo

O UrnaLab é um sistema de votação nominal para eleições escolares do Grêmio Estudantil.

O sistema registra:

- Alunos;
- Chapas;
- Votos identificados;
- Data e hora da votação;
- Relatórios;
- Comprovantes impressos.

## 2. Usuários do sistema

### Administrador

Pode:

- Cadastrar alunos;
- Cadastrar chapas;
- Liberar votações;
- Consultar relatórios;
- Imprimir relatórios.

### Mesário

Pode:

- Buscar o aluno pelo RA ou matrícula;
- Conferir se o aluno está ativo;
- Liberar o aluno para votar.

### Aluno

Pode:

- Escolher uma chapa;
- Confirmar o voto;
- Receber o comprovante, quando a impressão estiver disponível.

## 3. Fluxo da votação

1. O administrador cadastra os alunos.
2. O administrador cadastra as chapas.
3. O mesário informa o RA do aluno.
4. O sistema verifica se o aluno está ativo.
5. O aluno escolhe uma chapa.
6. O sistema registra o voto.
7. O sistema marca que o aluno já votou.
8. O comprovante pode ser impresso.
9. O voto aparece no relatório nominal.

## 4. Regra de voto único

Cada aluno pode votar apenas uma vez.

Caso o aluno tente votar novamente, o sistema bloqueará a operação.

## 5. Relatórios

O relatório apresenta:

- RA ou matrícula;
- Nome do aluno;
- Turma;
- Número da chapa;
- Nome da chapa;
- Data e hora do voto.

## 6. Impressão

O sistema permite selecionar uma impressora instalada no Windows.

Também é possível utilizar:

- Impressora comum;
- Impressora térmica;
- Microsoft Print to PDF.

Caso ocorra uma falha, o sistema exibirá uma mensagem informando o problema.

## 7. Observação

Esta versão é uma simulação educacional de uma urna escolar. Ela deve ser utilizada somente com autorização e acompanhamento da escola.

## Teste de aceitação final

- Login do administrador: aprovado
- Login do mesário: aprovado
- Cadastro de aluno: aprovado
- Cadastro de chapa: aprovado
- Liberação de votação: aprovado
- Registro de voto nominal: aprovado
- Bloqueio de voto duplicado: aprovado
- Relatório nominal: aprovado
- Resumo por chapa: aprovado
- Exportação: aprovado
- Impressão: aprovado