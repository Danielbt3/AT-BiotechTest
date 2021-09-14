# AT-BiotechTest

El proyecto es un servicio basico REST basado en .NET 5
Se ha seguido el modelo MVC

Para iniciar el proyecto tan solo habra que abrirlo en visual studio y iniciar ATBiotechTest , esto nos deberia abrir la interfaz de usuario por defecto(swagger).
A partir de aqui ya se podrian empezar a realizar llamadas , ya sea por API o usando el propio swagger

Notas:
-Se ha extraido la inyeccion de dependencias a una clase container para encontrarla mas facilmente

-Se eligio SQLite como base de datos ya que es un formato sencillo de SQL que permite ejecutar este test rapidamente y sin migraciones previas, en situaciones normales
hubiera montado una base de datos en postgresql

-Este proyecto se ha realizado en 2 horas de acuerdo al documento solicitado , en mi git se pueden encontrar otros proyectos de .Net con mas extension como este:
https://github.com/Danielbt3/Martian_Robots que incluye otras tecnologias como tests y tambien esta basado en SQLite y Net 5

-Como interfaz se ha dejado el propio swagger , si fuera necesario por favor notifiquenmelo para crear una interfaz basica en html y css
