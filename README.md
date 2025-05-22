# 🚀 Vision Hive

**Vision Hive** é uma API RESTful desenvolvida para a empresa Mottu com o objetivo de facilitar o gerenciamento e localização de motos nos pátios operacionais. A aplicação organiza motos por **Filiais** e **Pátios**, permitindo controle detalhado e busca eficiente.

---

## 🔗 Rotas Disponíveis

### 🏢 Filial
| Verbo | Rota                | Descrição                         |
|-------|---------------------|-----------------------------------|
| GET   | `/api/filial`       | Lista todas as filiais com pátios |
| GET   | `/api/filial/{id}`  | Detalha uma filial por ID         |
| POST  | `/api/filial`       | Cadastra uma nova filial          |
| PUT   | `/api/filial/{id}`  | Atualiza os dados da filial       |
| DELETE| `/api/filial/{id}`  | Remove uma filial existente       |

### 🏞️  Pátio
| Verbo | Rota                | Descrição                         |
|-------|---------------------|-----------------------------------|
| GET   | `/api/patio`        | Lista todas os pátios com motos   |
| GET   | `/api/patio/{id}`   | Detalha um pátio por ID           |
| POST  | `/api/patio`        | Cadastra um novo pátio            |
| PUT   | `/api/patio/{id}`   | Atualiza os dados do pátio        |
| DELETE| `/api/patio/{id}`   | Remove um pátio existente         |


### 🛵 Moto
| Verbo | Rota                   | Descrição                                     |
|-------|------------------------|-----------------------------------------------|
| GET   | `/api/moto`            | Lista todas as motos cadastradas              |
| GET   | `/api/moto/{id}`       | Detalha uma moto por ID                       |
| GET   | `/api/moto/buscar`     | Busca por placa, chassi ou número do motor    |
| POST  | `/api/moto`            | Cadastra uma nova moto                        |
| PUT   | `/api/moto/{id}`       | Atualiza os dados da moto                     |
| DELETE| `/api/moto/{id}`       | Remove uma moto existente                     |

---

## 🛠 Tecnologias Utilizadas

- ASP.NET Core 8 Web API
- Entity Framework Core
- Banco de Dados Oracle
- Swagger (documentação automática)
- Serialização JSON com `ReferenceHandler.IgnoreCycles`

---

## 🧪 Exemplos de Testes

### 🔹 Criar Filial

**POST /api/filial**

```json
{
  "nome": "Filial Centro",
  "bairro": "Jardins",
  "cnpj": "12.345.678/0001-90"
}

```

---

### 🔹 Criar Pátio

**POST /api/patio**

```json
{
  "nome": "Pátio Central",
  "limiteMotos": 50,
  "filialId": "COLE_AQUI_O_ID_DA_FILIAL"
}

```

> Substitua o filialId pelo valor real retornado no POST de filial.

---

### 🔹 Criar Moto

**POST /api/moto**

```json
{
  "placa": "XYZ9K88",
  "chassi": "9BWZZZ377VT004251",
  "numeroMotor": "MTR1234567",
  "prioridade": "Alta",
  "patioId": "COLE_AQUI_O_ID_DO_PATIO"
}

```

> Substitua o patioId pelo valor real retornado no POST de pátio.

---

### 🔹 Buscar Moto por Placa

**GET /api/moto/buscar?placa=XYZ9K88**

---

### 🔹 Detalhar Pátio com Motos

**GET /api/patio/{id}**

**Resposta esperada:**

```json
{
  "id": "patio-guid",
  "nome": "Pátio Central",
  "limiteMotos": 50,
  "motos": [
    {
      "id": "moto-guid",
      "placa": "XYZ9K88",
      "chassi": "9BWZZZ377VT004251",
      "numeroMotor": "MTR1234567",
      "prioridade": "Alta"
    }
  ]
}

```

---

### 🔹 Detalhar Filial com Pátios

**GET /api/filial/{id}**

**Resposta esperada:**

```json
{
  "id": "filial-guid",
  "nome": "Filial Centro",
  "bairro": "Jardins",
  "cnpj": "12.345.678/0001-90",
  "patios": [
    {
      "id": "patio-guid",
      "nome": "Pátio Central",
      "limiteMotos": 50
    }
  ]
}


```

## 🚀 Instruções de Execução

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/VisionHive.git
   ```

2. Configure a string de conexão Oracle no `appsettings.json`:
   ```json
   "ConnectionStrings": {
     "Oracle": "Data Source=localhost:1521/ORCL;User Id=SEU_USUARIO;Password=SUA_SENHA;"
   }
   ```

3. Aplique a migration:
   ```bash
   dotnet ef database update
   ```

4. Execute o projeto:
   ```bash
   dotnet run
   ```

5. Acesse o Swagger:
   ```
   https://localhost:{porta}/swagger
   ```

---

## 👥 Integrantes

| Nome                   | RM       |
|------------------------|----------|
| Larissa Muniz          | RM557197 |
| João Victor Michaeli   | RM555678 |
| Henrique Garcia        | RM558062 |

---

> Projeto acadêmico desenvolvido na FIAP para o Challenge 2025 — Sprint 1
