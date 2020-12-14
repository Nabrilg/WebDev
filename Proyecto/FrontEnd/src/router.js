/* import { analytics } from 'firebase' */
import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

const router = new Router({
    mode: 'history',
    base: process.env.BASE_URL,
    scrollBehavior () {
        return { x: 0, y: 0 }
    },
    routes: [

        {
    // =============================================================================
    // MAIN LAYOUT ROUTES
    // =============================================================================
            path: '',
            component: () => import('./layouts/main/Main.vue'),
            children: [
        // =============================================================================
        // Theme Routes
        // =============================================================================
              {
                path: '/',
                name: 'home',
                component: () => import('./views/PagesGeneral/Home.vue'),
              },
              {
                path: '/listadoUsuarios',
                name: 'listadoUsuarios',
                component: () => import('./views/UsersViews/ListadoUsuarios.vue')
              },
              {
                path: '/listadoConceptos',
                name: 'listadoConceptos',
                component: () => import('./views/ConceptsViews/ListadoConceptos.vue')
              },
              {
                path: '/crearUsuario',
                name: 'crearUsuario',
                component: () => import('./views/UsersViews/CrearUsuario.vue')
              },
              {
                path: '/crearConcepto',
                name: 'crearConcepto',
                component: () => import('./views/ConceptsViews/CrearConcepto.vue')
              },
              {
                path: '/logout',
                name: 'logout',
                component: () => import('./views/PagesGeneral/Logout.vue')
              },
            ],
        },
    // =============================================================================
    // FULL PAGE LAYOUTS
    // =============================================================================
        {
            path: '',
            component: () => import('@/layouts/full-page/FullPage.vue'),
            children: [
        // =============================================================================
        // PAGES
        // =============================================================================
              {
                path: '/login',
                name: 'page-login',
                component: () => import('@/views/PagesGeneral/Login.vue')
              },
              {
                path: '/error-404',
                name: 'page-error-404',
                component: () => import('@/views/PagesGeneral/Error404.vue')
              },
            ]
        },
        // Redirect to 404 page, if no match found
        {
            path: '*',
            redirect: '/error-404'
        }
    ],
})

//Para bloquear todas las rutas, sólo cambiando el parametro de next por un false
router.beforeEach((to, from, next)=>{
  const publicPages = ['/login', '/error-404']; //Paginas bloqueadas si no detecta que está bloqueado
  const LoginPages = ['/login'];
  //const publicPages = ['/login', '/', '/error-404', '/crearConcepto', '/crearUsuario', '/listadoConceptos', '/listadoUsuarios'];
  const authRequired = !publicPages.includes(to.path);
  const authRequired2 = !LoginPages.includes(to.path);
  const loggedIn = localStorage.getItem('_token');
  // trying to access a restricted page + not logged in
  // redirect to login page
  if (authRequired && !loggedIn) {
    next('/login');
  }else if(!authRequired2 && loggedIn){
    next('/');
  } else {
    next();
  }
});

router.afterEach(() => {
  // Remove initial loading
  const appLoading = document.getElementById('loading-bg')
    if (appLoading) {
        appLoading.style.display = "none";
    }
})

export default router