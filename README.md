# udemyBloggie.Web
## ASP.NET MVC / Entity Framework / MySqlServer 
### Froala / Cloudinary

Aula 01 - Criação do projeto MVC,
Criação do Models Domain.
Instalação do Entity Framework,
Criação do DbContext para o funcionamento do Entity Framework,
Conexão com obanco de dados através do DbContext,
Explicação das Migrations,
Inserção das Migrations.

Aula 02 - Começo da tag CRUD,
Controller AdminTags criado com metodo GET Add,
View de Add criada,
Adicionado no layout principal da aplicação um navbar do bootstrap para Admin e comandos do ASP para acessá-las,
Formulário para Tag Admin.

Aula 03 - Integração com o banco de dados,
Criação de tags,
Listagem de tags,
Como ter código C# dentro de uma razor page (.cshtml)
Delete de tags,
Criação das view List Add e Edit,
ViewModels como uma boa pratica.
Sistema CRUD completo.

Aula 04 - Asynchronous Programming and Repository Pattern.
Programação Ássincrona para os metodos (obs: bem tranquilo de se fazer no c# asp.net com ajuda do Entity Framework),
Criação de Repositories/ItagInterface.cs,
Os controladores são dependentes do TagRepository.cs.

Aula 05 - Criando novo Controller (Admin Blogs),
Criando HTML Form para adicionar o blog,
Implementando Model View e Controller para a criação de uma matéria do blog,
BlogPost CRUD - DropDowns CheckBox, DatePickers etc.

Aula 06 - Introdução ao WYSIWYG
significado - "What You See Is What You Get - O que você vê é o formato final".
Introdução do Froala agora é possivel criar uma página sem precisar utilizar HTML.
Implementação do Froala na página "Add.cshtml" no id "content".
obs: Froala versão Free.
Implementado Froala na página "Edit.cshtml".
Criar uma API para upload de imagens.
Introdução ao Cloudinary.
Instalação via Nugget do Cloudinary.
Views AdminBlogPosts:
	Add.cshtml adicionado o upload da imagem via Cloudinary e com a possibilidade de visualisação.
	Edit.cshtml adicionado Cloudinary.
Adicionado um método para o Froala conseguir reproduzir imagens através do Cloudinary.

Aula 07 - Blogs e Tags para usuários.
Toda a base para a montagem do blog completa.
Mostra a capa titulo e tags na home.
Ao clicar, o usuário é redirecionado para a postagem do bloggie.
