# Projeto RabbitMQ

Esse projeto consiste em um sistema de notificações utilizando o RabbitMQ, o projeto tem como objetivo entender como a ferramenta de mensageria funciona, juntamente com a sua integração a uma linguagem de programação.

<p style="color: red">
    Esse é um projeto com objetivo apenas de um estudo inicial, por conta disso questões de arquitetura, design pattern e outros não foram levados em conta na sua criação.
</p>

## Projetos

1. **Project.Rabbit.Producer**: API com um metódo HTTP POST, responsável por coletar os dados da notificação e chamar o serviço de mensageria (RabbitMQ) para colocar as informações na fila.
2. **Project.Rabbit.Consumer**: Programa de console simples que ao receber o evento de que tem uma nova mensagem na fila, resgata os dados e exibe na tela do console.