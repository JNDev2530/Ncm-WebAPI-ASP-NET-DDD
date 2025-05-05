**NcmAPI** é uma Web API em ASP .NET Core que expõe consultas e gerenciamento de códigos NCM (Nomenclatura Comum do Mercosul) seguindo princípios de **DDD**, **SOLID**, **Repository+UnitOfWork** e **autenticação JWT**.  
Ela permite:

- Consultar quais _NewNcm_ estão vinculados a um _OldNcm_.
- Registrar novos códigos NCM (protegido por JWT).
- Registrar e autenticar usuários via JWT.

---

## 📦 Tecnologias

- **.NET 6 / ASP.NET Core Web API**  
- **Entity Framework Core** (SQL Server)  
- **Domain‑Driven Design** (Entities, Value Objects, Repositories, UoW)  
- **SOLID** (SRP, DIP, etc.)  
- **JWT** para autenticação  
- **Swagger** para documentação interativa  
