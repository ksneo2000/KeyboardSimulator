<template>
    <div class="Registration">

        <h1>Registration</h1>


        <p><b>Введите Имя:</b><br></p>
        <input v-model="name" type="text" id="name" name="name" size="40" />
        <p><b>Введите Фамилию:</b><br></p>
        <input v-model="name" type="text" id="surname" name="surname" size="40" />
        <p><b>Введите E-mail:</b><br></p>
        <input v-model="name" type="text" id="email" name="email" size="40" />
        <p><b>Введите пароль:</b><br></p>
        <input v-model="password" type=password id="password" name="password" size="38" />
        <input type="button" value=" ">
        <p><b>Введите повторно пароль:</b><br></p>
        <input v-model="password2" type=password id="passwordTwo" name="passwordTwo" size="38" />
        <input type="button" value=" ">
        <p><b>Введите пол:</b><br></p>
        <input v-model="name" type="text" id="gender" name="gender" size="40" />
        <p><b>Введите Дату рождения:</b><br></p>
        <input v-model="name" type="text" id="dateofBirth" name="dateofBirth" size="40" />
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
                        password: this.password,
                        passwordTwo: this.password2,
                        email: this.email,
                        gender: this.gender,
                        dateofBirth: this.dateofBirth
                    };


                    axios({
                        method: 'Post',
                        url: '/UserRegistration/Registration',
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
