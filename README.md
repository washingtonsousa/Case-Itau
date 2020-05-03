# Case Itaú Estatísticas do Brasileirão

## Projeto desenvolvido com Web API .Net Core 3 e MySQL 8 (MariaDb)

### Iniciando aplicação

Antes de obter os dados você precisa primeiro configurar a conexão com banco de dados, para isso abra a solution dentro da pasta API e dentro do projeto Web altere o arquivo appsettings.json na sessão de Connection Strings.

A Conection String que deve ser alterada é a "Main".

Após este processo inicie a aplicação e ela estará pronta para ser testada.

Dentro da raíz do projeto é disponibilizada uma collection com endpoints pré inseridos para serem chamados e visualizar os resultados, importe para o postman e os execute após a importação de dados.

Antes de testar os endpoints de estatísticas é necessário primeiro realizar o processo de importação de dados que é feito direto do arquivo "Dados.txt" que está na pasta AppData no projeto Web. 

Atenção! Não altere este arquivo, caso contrário o processo de importação não irá funcionar, caso os dados estejam ordenados de forma errada neste arquivo o processo sempre ocasionará em erro.

Após iniciar a aplicação realize a importação de dados executando a Request "Importação de dados" (POST v1/api/importacao) contida na collection, se tudo der certo o retorno será com status 200 OK e a API estará pronta para obter os resultados.

Para obter os resultados a partir daqui é bem simples utilize as demais requests da collection, são destas os endpoints:

GET v1/api/estatisticas/resultado-geral >>>>> Obtém resultado geral da sessão Info Complementares
GET v1/api/estatisticas/estado >>>>> Obtém estatísticas por estado
GET v1/api/estatisticas/time/{{Nome do Time}}  >>>>> Obtém estatísticas por time e filtra pelo time selecionado
GET v1/api/estatisticas/time >>>>> Obtém estatísticas por time

Caso tudo esteja certo os resultados serão obtidos conforme executar os endpoints.

Para acompanhar os logs de trace utilize o console de saída do VS ou o Visualizador de Eventos do Windows.

# Testes Unitários
