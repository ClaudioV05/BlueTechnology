import Vue from 'vue';
import Router from 'vue-router';
import Contatos from './components/Contato/Contatos'
import ContatosDetalhe from './components/Contato/ContatosDetalhe'
import Sobre from './components/Sobre/Sobre'

Vue.use(Router);

export default new Router({
    routes: [
        {
            path: '/todosContatos',
            nome: 'contatos',
            component: Contatos
        },
        {
            path: '/contatoDetalhe/:id',
            nome: 'contatosDetalhe',
            component: ContatosDetalhe
        },
        {
            path: '/sobre',
            nome: 'Sobre',
            component: Sobre
        }
    ]
})