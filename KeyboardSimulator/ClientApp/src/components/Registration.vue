﻿<template>
    <div class="Registration">

        <h1>Registration</h1>


        <p><b>Введите Имя:</b><br></p>
        <input v-model="name" type="text" id="name" name="name" size="40" />
        <p><b>Введите Фамилию:</b><br></p>
        <input v-model="surname" type="text" id="surname" name="surname" size="40" />
        <p><b>Введите E-mail:</b><br></p>
        <input v-model="email" type="text" id="email" name="email" size="40" />
        <p><b>Введите пароль:</b><br></p>
        <input v-model="password" type=password id="password" name="password" size="38" />
        <input type="button" value=" ">
        <p><b>Введите повторно пароль:</b><br></p>
        <input v-model="passwordTwo" type=password id="passwordTwo" name="passwordTwo" size="38" />
        <input type="button" value=" ">

        <div>
            <strong>Введите пол:</strong>
            <br />
            <select v-model="gender" id="gender" name="gender" style="width:322px">
                <option value="man">Мужчина</option>
                <option value="woman">Женщина</option>

            </select>
        </div>

        <!--        <p><b>Введите Дату рождения:</b><br></p>
        <input v-model="dateOfBirth" type="text" id="dateOfBirth" name="dateOfBirth" size="40" />
    -->
        <div>
            <label for="dateOfBirth" >Введите Дату рождения:</label>
            <div>
                <input id="dateOfBirth" type="date" v-model="dateOfBirth"  />
            </div>
        </div>
        <br>
        <br>
        <span id='hiddenTwoPassword' style="display: none">{{errorMessage}}</span>
        <br>
        <br>
        <button v-on:click="clickone">OK</button>


        <br>

        <img src="../assets/logo.png" />
        <br>



    </div>
</template>

<script>
    import axios from 'axios'
    // import router from "../router/index.js";


    export default {


        name: 'Registration',
        data() {
            return {
                errorMessage: "",

            }
        },
        components: {

        },
        props: {

        },
        methods: {
            clickone: function () {
                // добавить проверку на пустоту полей name и password
                this.errorMessage = ""
                var spTwoPassword = document.getElementById('hiddenTwoPassword');
                if (this.name == "") {
                    this.errorMessage = "Поле Логин не должно быть пустым";

                }
                if (this.password == "") {
                    this.errorMessage = "Поле Пароль не должно быть пустым";

                }
                if (this.password != this.passwordTwo) {
                    this.errorMessage = "Вы ввели несовпадающие пароли";

                }
                if (this.errorMessage == "") {

                    spTwoPassword.setAttribute('style', "display: none");
                    const article = {
                        name: this.name,
                        surname: this.surname,
                        email: this.email,
                        password: this.password,
                        passwordTwo: this.passwordTwo,
                        gender: this.gender,
                        dateOfBirth: this.dateOfBirth
                    };


                    axios({
                        method: 'Post',
                        url: '/User/Registration',
                        data: article

                    })
                        .then(function (response) {
                            console.log(response.data);
                            //   router.push({ path: '/Answer' })
                        })
                        .catch(function (error) {
                            console.log(error);
                        });

                    console.log(article);

                }
                else {
                    spTwoPassword.removeAttribute("style");
                }

            }
        }
    }
</script>







<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    h3 {
        margin: 40px 0 0;
    }

    ul {
        list-style-type: none;
        padding: 0;
    }

    li {
        display: inline-block;
        margin: 0 10px;
    }

    a {
        color: #42b983;
    }
</style>
