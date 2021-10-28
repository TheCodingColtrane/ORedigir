// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


// Write your JavaScript code.

async function novoUsuario() {
    const nome = document.getElementById('nome').value;
    const email = document.getElementById('email').value;
    const senha = document.getElementById('senha').value;
    const dataNascimento = document.getElementById('nascimento').value;
    const tipoUsuarioId = document.getElementById('tipo');
    const tipoUsuario = tipoUsuarioId.options[tipoUsuarioId.selectedIndex].value;
    const dados = {
        method: 'POST',
        mode: 'cors',
        body: JSON.stringify({
            nomeCompleto: nome, email: email, senha: senha, dataNascimento: dataNascimento, tipoUsuario: parseInt(tipoUsuario)
        }),
        cache: 'no-cache',
        headers: {
            'content-type': 'application/json',
            'Access-Control-Allow-Origin': '*'
        }
    };

     const req = await fetch('/administrativo/registrar', dados);
    req.json().then((resultado) => {
        alert(resultado.recursoCriado);
    }).catch((e) => {
        alert(e);
    });
}

async function deletarUsuario() {

    const resposta = confirm('Deseja deletar este usuário ?', "Sim", "Não");
    const id = document.getElementById('idUsuario').value;
    if(resposta == true){
        const pesquisa = {
            method: 'POST',
            mode: 'cors',
            body: JSON.stringify({ id: id }),
            cache: 'no-cache',
            headers: {
                'content-type': 'application/json',
                'Access-Control-Allow-Origin': '*'
            }
        };

        const req = await fetch('/administrativo/deletar', pesquisa);
        req.json().then((resultado) => {
            alert(resultado.msg);
            window.location = '/administrativo';
        }).catch((err) => {
            console.error(err);
            window.location = '/administrativo';
        });
    }
 
}

async function atualizarUsuario() {
    const idUsuario = document.getElementById('idUsuario').value;
    const idPapel = document.getElementById('idPapel').value;
    const seo = document.getElementById('SEO').value;
    const cargo = document.getElementById('cargoAtual').value;
    const nome = document.getElementById('nome').value;
    const email = document.getElementById('email').value;
    const senha = document.getElementById('senha').value;
    const dataNascimento = document.getElementById('nascimento').value;
    const tipoUsuarioId = document.getElementById('tipo');
    const tipoUsuario = tipoUsuarioId.options[tipoUsuarioId.selectedIndex].value;
    const dados = {
        method: 'POST',
        mode: 'cors',
        body: JSON.stringify({
            nomeCompleto: nome, email: email, senha: senha, dataNascimento: dataNascimento, tipoUsuario: parseInt(tipoUsuario), idUsuario: idUsuario, idPapel: idUsuario, name: cargo 
        }),
        cache: 'no-cache',
        headers: {
            'content-type': 'application/json',
            'Access-Control-Allow-Origin': '*'
        }
    };

    const req = await fetch('/administrativo/atualizar/'+ idUsuario +'/' + idPapel + '/' + seo , dados);
    req.json().then((resultado) => {
        alert(resultado.msg);
    }).catch((e) => {
        alert(e);
    });
}