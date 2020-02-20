<template>
  <div id="app">
    <h1>Welcome to the amazing Rndm Nmbr Gnrtr!</h1>

    <div id="main-container">
      <div id="random-number-container">
        <span>
          {{ currentNumber ? currentNumber : "-----" }}
        </span>
      </div>

      <div id="button-container">
        <button id="generate-button" v-on:click="generateRandomNumber">
          Generate New Random Number
        </button>

        <button id="reset-button" v-on:click="resetAll">
          Reset All
        </button>
      </div>
    </div>

    <div id="number-list" v-if="previouslyGeneratedNumbers.length > 0">
      <span>Previously Generated Numbers</span>
      <NumberList v-bind:list=previouslyGeneratedNumbers />
    </div>
  </div>
</template>

<script>
import axios from "axios"
import NumberList from './components/NumberList.vue'

export default {
  name: 'app',
  components: {
    NumberList
},

  data() {
    return {
      currentNumber: undefined,
      previouslyGeneratedNumbers: []
    }
  },

  methods: {
    generateRandomNumber: function () {
      //post request to generate new number
      axios
        .post('https://localhost:44330/randomnumber')
        .then(response => {
          this.currentNumber = response.data.value
          this.previouslyGeneratedNumbers.push(this.currentNumber)
        })
    },
    resetAll: function () {
      axios
        .delete('https://localhost:44330/randomnumber')
        .then(() => {
          this.currentNumber = undefined;
          this.previouslyGeneratedNumbers = []
        })
    }
  },

  mounted () {
    //after app component is mounted, fetch existing random numbers, if any
    axios
        .get('https://localhost:44330/randomnumber')
        .then(response => {
          this.previouslyGeneratedNumbers = response.data.map(item => item.value) || [];
        })
  }
}
</script>

<style>
#app {
  font-family: "Share Tech Mono", monospace, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

#number-list {
  max-height: 400px;
  max-width: 400px;
  height: 400px;
  width: 400px;
}

#random-number-container {
  font-size: 50px;
  margin-bottom: 60px;
}

#generate-button {
  color: #FFFFFF;
  background-color: #42b983;
  border: none;
}

#reset-button {
  color: black;
  background-color: white;
  border: 1.5px solid black;
}

@media only screen and (min-width: 875px) and (min-height: 550px) {
  #main-container {
    position: absolute;
    top: 35%;
    left: 40%
  }
}

@media only screen and (max-width: 875px) {
  #number-list {
    transform: translate(-50%);
    position: absolute;
    left: 50%;
    margin-top: 30px;
    max-width: 300px;
  }

  #random-number-container {
    margin-bottom: 30px;
  }
}

@media only screen and (max-height: 550px){
  #number-list {
    transform: translate(-50%);
    position: absolute;
    left: 50%;
    margin-top: 30px;
    max-width: 300px;
  }

  #random-number-container {
    margin-bottom: 30px;
  }
}

h1 {
  margin-bottom: 50px;
}

span {
  display: block;
  margin-top: 20px;
  margin-bottom: 10px;
}

button {
  font-size: 16px;
  font-family: inherit;
  border-radius: 40px;
  padding: 15px 32px;
  text-align: center;
  text-decoration: none;
  cursor: pointer;
  width: 300px;
  outline: none;
  margin: 10px;
}
</style>
