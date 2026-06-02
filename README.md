# 🍔 Good Hamburger - Sistema de Pedidos / Order Management System

*(English version below / Versão em inglês abaixo)*

---

## 🇧🇷 Português (BR)

Este repositório contém o código-fonte do **Good Hamburger**, um sistema de gestão de pedidos que desenvolvi como solução para um desafio técnico. Estruturei o projeto com o objetivo de demonstrar a aplicação de boas práticas de engenharia de software, priorizando um código limpo, focado nas regras de negócio e acompanhado de uma interface de usuário.

### 1. 🛠️ Tecnologias Utilizadas
As principais tecnologias e frameworks que adotei incluem:
* **Backend:** C# com **.NET 10** (ASP.NET Core) para o desenvolvimento da API REST e **Scalar** para a documentação interativa dos endpoints.
* **Frontend:** **Blazor** (.NET 10) utilizando os componentes visuais da biblioteca **Radzen Blazor**, responsável por consumir a API e prover uma interface ágil e interativa para a operação do caixa.

### 2. 🚀 Funcionalidades
Desenhei a API para atender ao ciclo de vida completo dos pedidos e à consulta do cardápio. Os endpoints disponíveis são:
* **Menu (Cardápio)**
    * `GET` Listar: Retorna todos os itens disponíveis no cardápio.
    * `GET` Listar (Bebidas): Retorna todos os itens disponíveis de bebidas.
    * `GET` Listar (Lanches): Retorna todos os itens disponíveis de lanches.
    * `GET` Listar (Acompanhamentos): Retorna todos os itens disponíveis de acompanhamentos.
* **Orders (Pedidos)**
    * `POST` Criar: Inicia um novo pedido a partir de uma lista de produtos.
    * `GET` Listar: Retorna o histórico de pedidos registrados.
    * `GET` Consultar por ID: Busca os detalhes de um pedido específico.
    * `POST` Adicionar Produto: Insere novos itens em um pedido existente.
    * `DELETE` Remover Produto: Retira um item específico do pedido.
    * `DELETE` Finalizar: Conclui o pedido (o fluxo atual inativa o registro, funcionando como um encerramento lógico do ciclo).
    * `DELETE` Deletar: Exclui permanentemente um pedido do sistema.

### 3. 🍔 Regras de Negócio
Encapsulei as regras de negócio referentes aos descontos e limites diretamente no domínio da aplicação:
* **Sanduíche + Batata Frita + Refrigerante:** Aplica 20% de desconto no valor total do pedido.
* **Sanduíche + Refrigerante:** Aplica 15% de desconto no valor total do pedido.
* **Sanduíche + Batata Frita:** Aplica 10% de desconto no valor total do pedido.
* **Validação de Duplicidade:** Limitei cada pedido estritamente a um sanduíche, uma batata e um refrigerante. A inserção de itens duplicados da mesma categoria é bloqueada, retornando uma mensagem de erro clara e descritiva.

### 4. 🏗️ Decisões de Arquitetura
Visando escalabilidade e facilidade de manutenção, baseei o projeto nos seguintes padrões e arquiteturas:
* **Clean Architecture e DDD (Domain-Driven Design):** Isolei e enriqueci o domínio. A entidade `Order` é responsável por gerenciar seu próprio estado, calcular os valores totais, aplicar descontos e impedir a entrada de itens inválidos.
* **Result Pattern:** Para o controle de fluxo e validações (como itens não encontrados ou categorias duplicadas), utilizei o padrão genérico `Result` na camada de aplicação. Isso evita o uso excessivo de exceções para validar regras de negócio e mantém os *Controllers* previsíveis e bem estruturados.
* **Mapeamento com Extension Methods:** Realizei a conversão e o mapeamento entre as entidades de domínio e os modelos de requisição/resposta utilizando métodos de extensão (*extension methods*), o que garante uma separação clara de responsabilidades e alta performance.
* **EF Core In-Memory:** Optei por utilizar este formato para facilitar a avaliação do código. A base de dados em memória permite clonar, compilar e executar o projeto imediatamente, sem configurações adicionais.

### 5. ⏳ Foco e Esforços
* Durante a execução deste projeto, **medi e direcionei meus esforços** na estruturação de uma API robusta e na entrega de um frontend fluido utilizando Blazor. Sendo assim, o foco principal foi garantir a integridade da arquitetura, das validações de domínio e da interface de usuário, deixando a escrita de testes automatizados para um segundo momento, caso necessário.

### 6. 💻 Como iniciar o projeto
Instruções para execução do projeto em ambiente local:

**Via Visual Studio:**
1. Abra o arquivo da solução `GoodHamburger.slnx`.
2. Clique com o botão direito na Solução (no *Solution Explorer*) e selecione **Propriedades (Properties)**.
3. Em "Projeto de Inicialização", escolha **Vários projetos de inicialização (Multiple startup projects)**.
4. Defina a "Ação" dos projetos `GoodHamburger.API` e `GoodHamburger.Web` como **Iniciar (Start)**.
5. Execute o projeto (F5).
> **Atenção:** Verifique se a porta local em que a API está rodando corresponde exatamente à porta configurada no frontend (na classe `Configurations.ApiConfig`).

**Via Terminal (CLI):**
1. Abra um terminal, navegue até a pasta da API (`cd SEU_LOCAL/Backend/GoodHamburger.API`) e execute o comando:
   `dotnet run --urls "https://localhost:7032"`
   *Caso queira utilizar o Scalar, abra o navegador e digite `"https://localhost:7032/docs"`*
2. Em um segundo terminal, navegue até a pasta do Frontend (`cd SEU_LOCAL/Frontend/GoodHamburger.Web`) e execute:
   `dotnet run --urls "https://localhost:7223"`
3. Observe as portas de rede (localhost) exibidas no console e acesse a URL do Frontend através do seu navegador.

---

## 🇺🇸 English

This repository contains the source code for **Good Hamburger**, an order management system that I developed as a technical challenge. I structured the project to demonstrate software engineering best practices, prioritizing clean code, a strong focus on business rules, and a functional user interface.

### 1. 🛠️ Technology Stack
The core technologies and frameworks I adopted include:
* **Backend:** C# with **.NET 10** (ASP.NET Core) for the REST API development and **Scalar** for interactive API documentation.
* **Frontend:** **Blazor** (.NET 10) utilizing **Radzen Blazor** UI components, responsible for consuming the API and providing an agile, interactive interface for point-of-sale operations.

### 2. 🚀 Features
I designed the API to cover the entire order lifecycle and menu consultation. The available endpoints are:
* **Menu**
    * `GET` List: Returns all available menu items.
    * `GET` List (Beverages): Returns all available beverage items.
    * `GET` List (Sandwiches): Returns all available sandwich items.
    * `GET` List (Side Dishes): Returns all available extras items.
* **Orders**
    * `POST` Create: Initializes a new order from a product list.
    * `GET` List: Returns the history of registered orders.
    * `GET` Get By ID: Fetches the details of a specific order.
    * `POST` Add Product: Inserts new items into an existing order.
    * `DELETE` Remove Product: Removes a specific item from an order.
    * `DELETE` Finish: Completes the order (the current workflow inactivates the record, acting as a logical closure).
    * `DELETE` Delete: Permanently removes an order from the system.

### 3. 🍔 Business Rules
I strictly encapsulated the discount and restriction logic directly within the application domain:
* **Sandwich + Fries + Soda:** Applies a 20% discount to the order's total amount.
* **Sandwich + Soda:** Applies a 15% discount to the order's total amount.
* **Sandwich + Fries:** Applies a 10% discount to the order's total amount.
* **Duplicate Validation:** I strictly limited each order to one sandwich, one fries, and one soda. Attempting to add duplicate items from the same category is blocked, returning a clear and descriptive error message.

### 4. 🏗️ Architectural Decisions
To ensure scalability and maintainability, I based the project on the following patterns:
* **Clean Architecture & DDD (Domain-Driven Design):** I isolated and enriched the domain. The `Order` entity manages its own state, calculates totals, applies discounts, and prevents invalid item entries.
* **Result Pattern:** For control flow and business validations (e.g., item not found or duplicate categories), I utilized the generic `Result` pattern in the application layer. This avoids relying on exceptions for business logic and keeps the Controllers clean and predictable.
* **Mapping with Extension Methods:** I implemented the mapping and data conversion between domain entities and request/response models using extension methods, ensuring a clear separation of concerns and high performance.
* **EF Core In-Memory:** I chose to use this format to simplify the evaluation process. The in-memory database allows you to clone, build, and run the project immediately without additional configurations.

### 5. ⏳ Focus and Efforts
* During this project, **I measured and directed my efforts** towards structuring a robust API and delivering a fluid frontend using Blazor. Therefore, the main focus was on ensuring the integrity of the architecture, domain validations, and user interface, leaving the writing of automated tests for a later stage, if necessary.

### 6. 💻 How to Run the Project
Instructions for running the application locally:

**Via Visual Studio:**
1. Open the `GoodHamburger.slnx` solution file.
2. Right-click the Solution in the *Solution Explorer* and select **Properties**.
3. Under "Startup Project", choose **Multiple startup projects**.
4. Set the "Action" for both `GoodHamburger.API` and `GoodHamburger.Web` to **Start**.
5. Run the application (F5).
> **Note:** Ensure that the local port the API is running on matches the port configured in the frontend (`Configurations.ApiConfig` class).

**Via Terminal (CLI):**
1. Open a terminal, navigate to the API directory (`cd YOUR_LOCAL_PATH/Backend/GoodHamburger.API`), and execute:
   `dotnet run --urls "https://localhost:7032"`
   *If you want to use Scalar, open your browser and navigate to `"https://localhost:7032/docs"`*
2. Open a second terminal, navigate to the Frontend directory (`cd YOUR_LOCAL_PATH/Frontend/GoodHamburger.Web`), and execute:
   `dotnet run --urls "https://localhost:7223"`
3. Check the console output for the assigned localhost ports and open the Frontend URL in your web browser.
