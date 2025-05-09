Teste-FioTec-WebAPI

- Esse repositório tem como objetivo avaliar o desenvolvedor com base na execução do seguinte teste:

Desenvolver utilizando padrão de arquitetura de software uma WebAPI Rest que
consulta WebAPI da plataforma INFODENGUE.

- O padrão de arquitetura deve ser escolhido pelo participante;

- O banco de dados utilizado deve ser SQL e providenciado pelo próprio
participante;

- A linguagem deve ser C#;

- A WebAPI Rest deve ser aberta, podendo ser utilizada por qualquer pessoa,
apenas informando nome e CPF;

- Os dados do solicitante (Nome e CPF) devem ser salvos no banco e não podem
se repetir. Se um usuário já solicitou alguma vez, na próxima deve apenas
referenciá-lo;

- Os dados da consulta à API da plataforma INFODENGUE deve ser salvos no
banco;

- Podem ser realizadas diversas requisições de relatórios;

- Todo relatório deve ser salvo em banco com as seguintes informações:
    - Data da solicitação;
    - Arbovirose;
    - Solicitante;
    - Semana de início;
    - Semana de término;
    - Código IBGE;
    - Município;

- Deve existir relacionamento entre as tabelas de solicitante e relatório;

- Deve ser possível listar todos os relatórios salvos no banco;

- Relatórios:
    - Listar todos os dados epidemiológicos do município do Rio de Janeiro e
    São Paulo;
    - Listar os dados epidemiológicos dos municípios pelo código IBGE;
    - Listar o total de casos epidemiológicos dos municípios do Rio de Janeiro
    e São Paulo;
    - Listar o total de casos epidemiológicos dos municípios por arbovirose;
    - Listar os solicitantes;

- A consulta de códigos IBGE dos munícipios pode ser realizada no link: link
https://www.ibge.gov.br/explica/codigos-dos-municipios.php

- Listar os dados epidemiológicos dos municípios pelo código IBGE, semana
início, semana fim e arbovirose; 

Documentação da API plataforma INFODENGUE: 
https://info.dengue.mat.br/services/api

Entrega do Projeto:
- Deve ser colocado em um repositório aberto do github, com o arquivo dump do
banco sql usado no projeto. 

