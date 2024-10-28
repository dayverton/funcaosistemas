# Aplicação web para cadastro de clientes e beneficiários

Aplicação ASP .NET com Framework 4.8 e banco SQL embutido.

## Requisitos Necessários

- Visual Studio 2022
Disponível em: https://visualstudio.microsoft.com/pt-br/downloads/

- Importante:
Na instalação do Visual Studio certique-se que as seguintes opcões estejam habilitadas na guia **Componentes Individuais**:
> Pacote de direcionamento do .NET Framework 4.8,
SDK do .NET Framework 4.8,
SQL Server Express 2019 LocalDB


## Como acessar

Para acessar a página:

[https://localhost:44333/Cliente](https://localhost:44333/Cliente)

## Adaptações importantes
Salvar o beneficiário no mesmo botão de cadastro do cliente resultaria em um forte acoplamento entre os dois domínios, dificultando a manutenção e testes do código. Essa implementação atribuiria ao controller do cliente a responsabilidade de manipular um segundo modelo (beneficiário), o que viola o princípio da responsabilidade única. Por esse motivo, adaptei o projeto para que as operações de beneficiário sejam realizadas de forma independente e salvas diretamente no banco de dados pelo controller do beneficiário.

## Solução para problemas pouco frequentes

Se tiver problemas para iniciar o banco de dados, siga os passos:

Localize a versão mais recente do SqlLocalDB:
```bash
dir "C:\Program Files\Microsoft SQL Server\sqllocaldb.exe" /S /B
```
Vá para o diretório com o número de versão mais alto, por exemplo.

```bash
cd "C:\Program Files\Microsoft SQL Server\150\Tools\Binn\"
```

Exclua a instância padrão do LocalDB:

```bash
SqlLocalDB.exe delete MSSQLLocalDB
```

Recrie a instância padrão do LocalDB:

```bash
SqlLocalDB.exe create MSSQLLocalDB
```


