# Entrega Final - WebDev - William Aguirre Zapata

## Desplegado en Servidor
[https://webdev.ventall.co](https://webdev.ventall.co)
## Restos y Aprendizaje Personal
### Framework de JavaScript
Quise retarme a aprender otro framework diferente a React pero basado en Javascript, por ello utilicé VueJS que une lo mejor de los dos mundos de React y Ángular.
### Framework CSS y Estilo
También quise utiliza otra librería de diseño diferente a Bootstrap y Material Design para salir de lo convencional y aprendí a manejar [Vuesax](https://github.com/lusaxweb/vuesax)
### Estructura
- Dentro de la Carpeta "src/views" Se encuentran las respectivas vistas de la aplicación, manejando el patrón de MVC y de componentes también utilizando plugins como router, axios, vuex-stores, para facilitar la codificación.
```
├── views
│   ├── ConceptsViews
|   |   ├── CrearConcepto.vue
|   |   ├── ListadoConceptos.vue
|   |   └── TablaConceptos.vue
|   ├── UserViews
|   |   ├── CrearUsuario.vue
|   |   ├── ListadoUsuarios.vue
|   |   └── TablaUsuarios.vue
|   └── PagesGeneral
|       ├── Error404.vue
|       ├── Home.vue
|       ├── Login.vue
|       └── Logout.vue
└── API_EndPoints.json
```
- El archivo "src/API_EndPoints.json" tiene las variables de los endpoints de las respectivas APIs por si se reemplaza las APIs 
```
{
    "users": "https://javerianawebdevapi.azurewebsites.net/api/users",
    "concepts": "https://javerianawebdevapi.azurewebsites.net/api/concepts",
    "login": "https://javerianawebdevapi.azurewebsites.net/api/login"
}
```
## Project setup
```
npm install
```

### Compiles and hot-reloads for development
```
npm run serve
```

### Compiles and minifies for production
```
npm run build
```

### Customize configuration
See [Configuration Reference](https://cli.vuejs.org/config/).
