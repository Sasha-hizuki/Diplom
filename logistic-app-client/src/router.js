import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

let router = new Router({
    linkActiveClass: 'active',
    linkExactActiveClass: 'exact-active',
    mode: 'history',
    routes: [
        {
            path:'/',
            meta: {
                requiresAuth: true
            }
        },
        {
            path:'/login',
            component: () => import('@/views/Login.vue')
        },
        {
            path:'/orders',
            component: () => import('@/views/Orders.vue'),
            meta: {
                requiresAuth: true
            }
        },
        {
            path:'/cars',
            component: () => import('@/views/Cars.vue'),
            meta: {
                requiresAuth: true
            }
        },
        {
            path:'/trailers',
            component: () => import('@/views/Trailers.vue'),
            meta: {
                requiresAuth: true
            }
        },
        {
            path:'/clients',
            component: () => import('@/views/Clients.vue'),
            meta: {
                requiresAuth: true
            }
        },
        {
            path:'/bordercrossings',
            component: () => import('@/views/BorderCrossings.vue'),
            meta: {
                requiresAuth: true
            }
        },
        {
            path:'/customs',
            component: () => import('@/views/Customs.vue'),
            meta: {
                requiresAuth: true
            }
        },
        {
            path:'/declarants',
            component: () => import('@/views/Declarants.vue'),
            meta: {
                requiresAuth: true
            }
        },
        {
            path:'/users',
            component: () => import('@/views/Users.vue'),
            meta: {
                requiresAuth: true
            }
        },
        {
            path:'/docs',
            component: () => import('@/views/Docs.vue'),
            meta: {
                requiresAuth: true
            }
        }
    ]
})

router.beforeEach((to, from, next) => {
    if(to.matched.some(record => record.meta.requiresAuth)) {   
        if (localStorage.getItem('jwt') === 'null' || localStorage.getItem('jwt') === '') {
            next({
                path: '/login'
            })
        } else {
            next()
        }
    }else{
        next()
    }
})

export default router
