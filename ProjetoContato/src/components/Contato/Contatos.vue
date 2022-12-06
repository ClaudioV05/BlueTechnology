<template>
  <div>
    <titulo :texto="'Lista'"/>
      <input type="text" placeholder="Novo Contato" v-model="nome" @keyup.enter="adicionarContato()">
      <button class="btn btnInput" @click="adicionarContato()">Adicionar</button>
    <table>
      <thead>
        <th></th>
        <th>Nome</th>
        <th>Opções</th>
      </thead>
      <tbody v-if="contato.length">
        <tr v-for="(pessoa, index) in contato" :key="index">
          <td class="colPequeno">{{pessoa.id}}</td>
          <router-link :to="`/contatoDetalhe/${pessoa.id}`" tag="td" style="cursor: pointer">
            {{pessoa.nome}} {{pessoa.sobrenome}}
          </router-link>
          <td class="colPequeno">
            <Button class="btn btn_Danger" @click="removerContato(pessoa)">Excluir</Button>
          </td>
        </tr>
      </tbody>
      <tfoot v-else>
         <tr>
          <td colspan="3" style="text-align: center">
            <h5>Nenhum Contato Encontrado</h5>
          </td>
        </tr>
      </tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from "../_share/Titulo";

export default {
  components: {
    Titulo
  },
  data() {
    return {
      titulo: "pessoa",
      nome: "",
      contato: []
    };
  },
  created() {
      this.$http
        .get("http://localhost:5000/api/pessoa")
        .then(res => res.json())
        .then(contato => (this.contato = contato));
  },
  props: {},
  methods: {
    adicionarContato() {
      let _pessoa = {
        nome: this.nome,
        sobrenome: "",
        dataNasc: ""
      };

      this.$http
        .post("http://localhost:5000/api/pessoa", _pessoa)
        .then(res => res.json())
        .then(pessoa => {
          this.contato.push(pessoa);
          this.nome = "";
        });
    },
    removerContato(pessoa) {
      this.$http.delete(`http://localhost:5000/api/pessoa/${pessoa.id}`).then(() => {
        let indice = this.contato.indexOf(pessoa);
        this.contato.splice(indice, 1);
      });
    }
  }
};
</script>

<style scoped>
input {
  width: calc(100% - 195px);
  border: 0;
  padding: 20px;
  font-size: 1.3em;
  color: #687f7f;
  display: inline;
}

.btnInput {
  width: 150px;
  border: 0px;
  padding: 20px;
  font-size: 1.3em;
  display: inline;
  background-color: rgb(116, 115, 115);
}

.btnInput:hover {
  padding: 20x;
  margin: 0px;
  border: 0px;
}
</style>
