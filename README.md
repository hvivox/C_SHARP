# C_SHARP

## Descrição

Este repositório contém o projeto "C_SHARP", que é um microserviço desenvolvido em API Web Asp.net. O objetivo do microserviço é receber um objeto no formato JSON via HTTP POST, armazenar esse objeto no banco de dados não relacional Azure Cosmos DB e enviar uma mensagem para uma fila do Azure Service Bus com as informações do objeto "Usuário" armazenado. Além disso, o microserviço "segundoservico" consome a fila e processa os objetos do banco de dados com base nos dados recebidos.

![APRESENTACAO](https://github.com/hvivox/C_SHARP/blob/main/ArquiteturaDesafio.png)


## Tecnologias Utilizadas

- API Web Asp.net
- Azure Cosmos DB
- Azure Service Bus

![funcionamento](https://github.com/hvivox/C_SHARP/blob/main/Funcionamento_primeiro_servico.gif)




## Configuração do Ambiente de Desenvolvimento

1. Clone este repositório: `git clone https://github.com/hvivox/C_SHARP.git`
2. Abra o projeto no Visual Studio.
3. Realize as configurações necessárias para se conectar ao Azure Cosmos DB e Azure Service Bus.
4. Certifique-se de ter uma instância do Azure Cosmos DB em execução e uma fila do Azure Service Bus configurada.

## Execução do Microserviço

1. Certifique-se de ter configurado corretamente o ambiente de desenvolvimento.
2. Compile e execute o projeto no Visual Studio.

## Uso

1. O microserviço "primeiroservico" está configurado para receber objetos no formato JSON via HTTP POST.
2. Os objetos recebidos são armazenados no banco de dados não relacional Azure Cosmos DB.
3. Após o armazenamento do objeto, uma mensagem é enviada para a fila do Azure Service Bus com as informações do objeto "Usuário" armazenado.
4. O microserviço "segundoservico" consome a fila e processa os objetos do banco de dados com base nos dados recebidos.


## Diagrama de classes 

![primeiroservico](https://github.com/hvivox/C_SHARP/blob/main/PRIMEIRO%20SERVICO_CLASS.png)

![segundoservico](https://github.com/hvivox/C_SHARP/blob/main/SEGUNDO%20SERVICO.png)


