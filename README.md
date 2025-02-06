## Test AnalyticalWays

# AcmeSchool - Gestion de Cursos y Estudiantes

Este proyecto es una **libreria de clases en c# (.NET 8 ) que implementa la lógica de negocio para la gestión de cursos y estudiantes siguiendo **arquitectura hexagonal, DDD, TDD, Clean Code y principios SOLID**.

## Caracteristicas	
- Registro de estudiantes (solo adultos).
- Registro de cursos con tarifa de inscripción, fecha de inicio y fin.
- Inscripción de estudiantes en cursos (validando pago cuando aplica).
- Consulta de inscripciones en un rango de fechas.
- **100% cobertura de pruebas unitarias con xUnit y Moq**.

## Estructura del proyecto
```plaintext
AcmeSchool (Solución)  
│── AcmeSchool.Core (Librería principal - Lógica de negocio)  
│    │── Domain (Modelo de dominio: entidades, value objects, excepciones)  
│    │── Application (Casos de uso y servicios)  
│        │── Interfaces (Definiciones de repositorios)  
│  
│── AcmeSchool.Tests (Pruebas unitarias con xUnit, Moq y FluentAssertions)  


## Decisiones Técnicas
- Se utilizó arquitectura hexagonal para garantizar un diseño desacoplado y flexible.
- DDD para modelar el dominio.
- Principios SOLID para mantener el código limpio y extensible.
- TDD (Test-Driven Development) asegurando la calidad del código desde el inicio.
- Se crearon abstracciones de repositorios (IStudentRepository, ICourseRepository, IEnrollmentRepository) para permitir futuras implementaciones con bases de datos.

## Instalación y Ejecución
### **1. Clonar el Repositorio**
```bash
git clone https://github.com/tu-repo/acme-school.git
cd acme-school

### **2. Abrir en Visual Studio**
1. Abrir AcmeSchool.sln.
2. Compilar el proyecto
3. Ejecutar pruebas en terminal con:
```bash
dotnet test

## Posibles Mejoras
- Persistencia de datos: Actualmente el sistema no usa base de datos, pero la arquitectura permite integrarla en el futuro.
- Publicación como API: Si se aprueba el PoC, se puede convertir en una API REST con ASP.NET Core.
- Implementar un servicio real de pagos en lugar de solo una validación booleana.


## Autor
- Oscar Sarmiento - oscarsarmientou@gmail.com
- +573153813223