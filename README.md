## Dependencias

- SQL Server

## Guía para levantar el Back-end

1. **Clonar el repositorio:**  
   Abre una terminal en la raíz donde planeas clonar el repositorio y ejecuta el siguiente comando:
   
   git clone https://github.com/GuidoLn/challenge-total-back.git
   
2. **Configuración de la base de datos:**  
La conexión a la base de datos se realiza mediante la autenticación de Windows. Si deseas utilizar otra forma de autenticación, modifica la cadena de conexión `ConnectionStrings` en tu archivo de configuración. Por ejemplo:  
```json
"DefaultConnection": "Server=localhost;Database=buttonsDB;Trusted_Connection=True; TrustServerCertificate=true"

