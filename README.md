# 🚀 Vision Hive

**Vision Hive** é uma API RESTful desenvolvida para a empresa Mottu com o objetivo de facilitar o gerenciamento e localização de motos nos pátios operacionais. A aplicação permite o cadastro de **Áreas** e **Motos**, associando motos às suas respectivas áreas, com busca por placa, chassi ou número do motor.

---

## 🔗 Rotas Disponíveis

### 📍 Área
| Verbo | Rota              | Descrição                      |
|-------|-------------------|-------------------------------|
| GET   | `/api/area`       | Lista todas as áreas          |
| GET   | `/api/area/{id}`  | Detalha uma área por ID       |
| POST  | `/api/area`       | Cadastra uma nova área        |
| PUT   | `/api/area/{id}`  | Atualiza os dados da área     |
| DELETE| `/api/area/{id}`  | Remove uma área existente     |

### 🛵 Moto
| Verbo | Rota                   | Descrição                                      |
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

### 🔹 Criar Área

**POST /api/area**

```json
{
  "nome": "Pátio Central"
}
```

---

### 🔹 Criar Moto

**POST /api/moto**

```json
{
  "placa": "XYZ9K88",
  "chassi": "9BWZZZ377VT004251",
  "numeroMotor": "MTR1234567",
  "prioridade": "Alta",
  "areaId": "COLE_AQUI_O_ID_DA_AREA"
}
```

> Substitua o `areaId` pelo valor real retornado no POST de área.

---

### 🔹 Buscar Moto por Placa

**GET /api/moto/buscar?placa=XYZ9K88**

---

### 🔹 Detalhar Área com Motos

**GET /api/area/{id}**

**Resposta esperada:**

```json
{
  "id": "area-guid",
  "nome": "Pátio Central",
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
