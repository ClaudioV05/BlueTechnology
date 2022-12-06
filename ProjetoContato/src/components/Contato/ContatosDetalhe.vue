<template>
  <div v-if="!loading">
    <titulo :texto="`Contato: ${pessoa.nome}`" :btnVoltar="!visualizando">
      <button v-show="visualizando" class="btn btnEditar" @click="editar()">Editar</button>
    </titulo>
    <table>
      <tbody>
        <tr>
          <td class="colPequeno">ID:</td>
          <td>
            <label>{{pessoa.id}}</label>
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Nome:</td>
          <td>
            <label v-if="visualizando">{{pessoa.nome}}</label>
            <input v-else v-model="pessoa.nome" type="text">
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Sobrenome:</td>
          <td>
            <label v-if="visualizando">{{pessoa.sobrenome}}</label>
            <input v-else v-model="pessoa.sobrenome" type="text">
          </td>
        </tr>
        <tr>
          <td class="colPequeno">D. Nascimento:</td>
          <td>
            <label v-if="visualizando">{{pessoa.dataNasc}}</label>
            <input v-else v-model="pessoa.dataNasc" type="text">
          </td>
        </tr>
        <tr>
          <td class="colPequeno">Telefone:</td>
          <td>
            <label v-if="visualizando">{{pessoa.telefone}}</label>
            <input v-else v-model="pessoa.telefone" type="text">
          </td>
        </tr>
      </tbody>
    </table>

    <div style="margin-top: 10px">
      <div v-if="!visualizando">
        <button class="btn btnSalvar" @click="salvar(pessoa)">Salvar</button>
        <button class="btn btnCancelar" @click="cancelar()">Cancelar</button>
      </div>
    </div>
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
      pessoa: {},
      idpessoa: this.$route.params.id,
      visualizando: true,
      loading: true
    };
  },
  created() {
    this.carregarpessoa();
  },
  methods: {
    carregarpessoa() {
      this.$http
        .get(`http://localhost:5000/api/pessoa/${this.idpessoa}`)
        .then(res => res.json())
        .then(pessoa => {
          this.pessoa = pessoa;
          this.loading = false;
        });
    },
    editar() {
      this.visualizando = !this.visualizando;
    },
    salvar(_pessoa) {
      let _pessoaEditar = {
        id: _pessoa.id,
        nome: _pessoa.nome,
        sobrenome: _pessoa.sobrenome,
        dataNasc: _pessoa.dataNasc,
        telefone: _pessoa.telefone,
      };

      this.$http
        .put(`http://localhost:5000/api/pessoa/${_pessoaEditar.id}`, _pessoaEditar)
        .then(res => res.json())
        .then(pessoa => this.pessoa = pessoa)
        .then(() => this.visualizando = true);

      this.visualizando = !this.visualizando;
    },
    cancelar() {
      this.visualizando = !this.visualizando;
    }
  }
};
</script>

<style scoped>
.btnEditar {
  float: right;
  background-color: rgb(76, 186, 249);
}

.btnSalvar {
  float: right;
  background-color: rgb(79, 196, 68);
}

.btnCancelar {
  float: left;
  background-color: rgb(249, 186, 92);
}

.colPequeno {
  width: 20%;
}

input,
select {
  margin: 0px;
  padding: 5px 10px;
  font-size: 0.9em;
  font-family: Montserrat;
  border-radius: 5px;
  border: 1px solid silver;
  background-color: rgb(245, 245, 245);
  width: 95%;
}

select {
  height: 38px;
  width: 100%;
}
</style>