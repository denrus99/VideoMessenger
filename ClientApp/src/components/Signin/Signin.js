import React, { useState } from 'react';
import cs from './Signin.module.css'

function Login(props) {
    let loginData = {
        emailAddress: undefined,
        password: undefined
    };

    return (
        <div className={cs.loginForm}>
            <div className={cs.complexInput}>
                <label htmlFor={'emailAddress'} className={cs.signinLabel}>Адрес e-mail</label>
                <input id={'emailAddress'} className={cs.signinInput} onChange={(event) => {
                    loginData.emailAddress = event.target.value;
                }} />
            </div>
            <div className={cs.complexInput}>
                <label htmlFor={'password'} className={cs.signinLabel}>Пароль</label>
                <input id={'password'} type={'password'} className={cs.signinInput} onChange={(event) => {
                    loginData.password = event.target.value;
                }} />
            </div>
            <button type={'button'} onClick={() => {
                if (loginData.emailAddress && loginData.password)
                    props.authenticateUser(false, loginData);
            }}>Войти
            </button>
        </div>
    );
}

function Signup(props) {
    let signupData = {
        login: undefined,
        phoneNumber: undefined,
        emailAddress: undefined,
        password: undefined
    };

    return (
        <div className={cs.signupForm}>
            <div className={cs.complexInput}>
                <label htmlFor={'login'} className={cs.signinLabel}>Логин</label>
                <input id={'login'} className={cs.signinInput} onChange={(event) => {
                    signupData.login = event.target.value;
                }} />
            </div>
            <div className={cs.complexInput}>
                <label htmlFor={'phoneNumber'} className={cs.signinLabel}>Телефон</label>
                <input id={'phoneNumber'} className={cs.signinInput} onChange={(event) => {
                    signupData.phoneNumber = event.target.value;
                }} />
            </div>
            <div className={cs.complexInput}>
                <label htmlFor={'emailAddress'} className={cs.signinLabel}>Адрес e-mail</label>
                <input id={'emailAddress'} className={cs.signinInput} onChange={(event) => {
                    signupData.emailAddress = event.target.value;
                }} />
            </div>
            <div className={cs.complexInput}>
                <label htmlFor={'password'} type={'password'} className={cs.signinLabel}>Пароль</label>
                <input id={'password'} className={cs.signinInput} onChange={(event) => {
                    signupData.password = event.target.value;
                }} />
            </div>
            <button type={'button'} onClick={() => {
                if (signupData.login && signupData.password && signupData.emailAddress && signupData.phoneNumber)
                    props.authenticateUser(true, signupData);
            }}>Войти
            </button>
        </div>
    );
}

function Signin(props) {
    const [login, setLogin] = useState(true);
    return (
        // <Container className='m-auto border border-3 p-3 rounded' style={{ width: '400px' }}>
        <div className={cs.authScreen}>
            <div className={cs.authForm}>
                <div className={cs.signinTabs}>
                    <button type={'button'} onClick={() => setLogin(true)}>Вход</button>
                    <button type={'button'} onClick={() => setLogin(false)}>Регистрация</button>
                </div>
                {login ? <Login authenticateUser={props.authenticateUser} /> :
                    <Signup authenticateUser={props.authenticateUser} />}
            </div>
        </div>
        // </Container>
    );
}


export default Signin;
