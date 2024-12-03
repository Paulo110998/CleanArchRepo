using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace CleanArchMvc.Infra.Data.Identity;

public class AuthenticateService : IAuthenticate
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthenticateService(UserManager<ApplicationUser> userManager, 
        SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    // Define um método assíncrono chamado "Authenticate" que retorna um booleano indicando sucesso ou falha.
    // O método recebe dois parâmetros: "email" e "password".
    public async Task<bool> Authenticate(string email, string password)
    {
        // Usa o "_signInManager" para tentar realizar a autenticação do usuário com o email e senha fornecidos.
        // A função "PasswordSignInAsync" tenta autenticar o usuário com base nos dados fornecidos.
        // O terceiro parâmetro "false" indica que a autenticação não deve lembrar o usuário em sessões futuras.
        // O quarto parâmetro "lockoutOnFailure: false" desabilita o bloqueio da conta em caso de falha de login.
        var result = await _signInManager.PasswordSignInAsync(
            email, password, false, lockoutOnFailure: false);

        // Retorna true se a autenticação foi bem-sucedida (result.Succeeded), caso contrário, retorna false.
        return result.Succeeded;
    }


    // O método recebe dois parâmetros: "email" e "password".
    public async Task<bool> RegisterUser(string email, string password)
    {
        // Cria uma nova instância de "ApplicationUser", representando um usuário do sistema.
        // A propriedade "UserName" e "Email" são inicializadas com o valor do email fornecido.
        var applicationUser = new ApplicationUser
        {
            UserName = email,
            Email = email,
        };

        // Usa o "_userManager" para criar o usuário no sistema com a senha fornecida.
        // A função "CreateAsync" tenta registrar o usuário no banco de dados.
        var result = await _userManager.CreateAsync(applicationUser, password);

        // Verifica se o processo de criação foi bem-sucedido.
        if (result.Succeeded)
        {
            // Se o registro foi bem-sucedido, realiza automaticamente o login do usuário recém-criado.
            // A função "SignInAsync" do "_signInManager" autentica o usuário no sistema.
            // O parâmetro "isPersistent: false" indica que a sessão do usuário não será persistida após fechar o navegador.
            await _signInManager.SignInAsync(
                applicationUser, isPersistent: false);
        }

        // Retorna true se o usuário foi criado com sucesso, caso contrário retorna false.
        return result.Succeeded;
    }


    // Define um método assíncrono chamado "Logout" que não retorna nenhum valor (void).
    public async Task Logout()
    {
        // Usa o "_signInManager" para finalizar a sessão do usuário autenticado.
        // A função "SignOutAsync" remove os cookies de autenticação e termina a sessão ativa.
        await _signInManager.SignOutAsync();
    }



}
