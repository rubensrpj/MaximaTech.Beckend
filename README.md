\## Conexão com o banco de dados



---



<aside>

💡



A configuração abaixo é para conectar no banco de dados criado no ambiente Supabase para o teste em questão.



</aside>



> host: \\\[aws-0-sa-east-1.pooler.supabase.com](http://aws-0-sa-east-1.pooler.supabase.com/)

port: 5432

database:postgres

user:postgres.itgqenloioctdiduipbq

pool\_mode:session
> 



## Script do banco de dados



---



```sql

-- DEPARTAMENTO

CREATE TABLE departamentos (
    id SERIAL PRIMARY KEY,
    codigo VARCHAR(10) NOT NULL UNIQUE,
    nome VARCHAR(50) NOT NULL UNIQUE
);

-- Inserção dos departamentos pré-definidos com códigos numéricos

INSERT INTO departamentos (codigo, nome) VALUES
('010', 'Bebidas'),
('020', 'Congelados'),
('030', 'Laticínios'),
('040', 'Vegetais');

-- Habilita extensão para geração de UUID caso não exista
CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

--PRODUTOS

CREATE TABLE produtos (
    id UUID PRIMARY KEY DEFAULT uuid _generate_v4(), -- Identificador único do produto
    codigo VARCHAR(50) NOT NULL UNIQUE, -- Código do produto
    descricao TEXT NOT NULL, -- Descrição detalhada do produto
    departamento_id INTEGER NOT NULL REFERENCES departamentos(id), -- FK para departamentos
    preco NUMERIC(12,2) NOT NULL, -- Preço do produto
    status BOOLEAN NOT NULL DEFAULT TRUE, -- Ativo (TRUE) ou Inativo (FALSE)
    criado_em TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP, -- Timestamp de criação
    atualizado_em TIMESTAMP -- Timestamp de atualização
);

```
## Clonar o projeto
---

```bash

git clone https://github.com/rubensrpj/MaximaTech.Beckend.git backend
cd backend
cd MaximaTech.Backend

```
## Atualizar o arquivo - appsettings.json
---

> Adicionar a string de conexão caso seja necessário, já está configurado para uma base teste.

> 

```json

"ConnectionStrings": {

  "DefaultConnection": "User Id=postgres.itgqenloioctdiduipbq;Password=uev1npy6DPM\\\*fvz4jzf;Server=aws-0-sa-east-1.pooler.supabase.com;Port=5432;Database=postgres"
}

```
## Executar o projeto
---
```bash
  dotnet run
```

