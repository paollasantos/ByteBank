
using bytebank;
using bytebank.Titular;

Console.WriteLine("Boas Vindas ao seu Banco, Bytebank!");

//ContaCorrente conta1 = new ContaCorrente();
//conta1.titular = "paola santos";
//conta1.conta = "10123-X";
//conta1.numero_agencia = 23;
//conta1.nome_agencia = "agência central";
//conta1.saldo = 100;

//ContaCorrente conta2 = new ContaCorrente();
//conta2.titular = "Lennon Lima";
//conta2.conta = "111999-X";
//conta2.numero_agencia = 58;
//conta2.nome_agencia = "Agência Central";
//conta2.saldo = 100;

//Cliente cliente = new Cliente();
//cliente.nome = "Paola Santos";
//cliente.cpf = "13221433905";
//cliente.profissao = "Programador C#";

//ContaCorrente conta3 = new ContaCorrente();
//conta3.titular = new Cliente();
//conta3.titular.nome = "Paola Santos";
//conta3.titular.cpf = "10253541263";
//conta3.titular.profissao = "Programador C#";
//conta3.conta = "2513252-X";
//conta3.numero_agencia = 35;
//conta3.nome_agencia = "Agência Central";

//Console.WriteLine(conta3.titular.nome);

//if (conta3.titular == null)
//{
//    Console.WriteLine("O campo titular está nulo");
//}

//Cliente sarah = new Cliente();
//sarah.Nome = "Sarah Silva";

//ContaCorrente conta4 = new ContaCorrente(235,"123456-X");
//conta4.Titular = sarah;
//conta4.Saldo = 100;

//Console.WriteLine(conta4.Titular.Nome);
//Console.WriteLine("Saldo:" + conta4.Saldo);
//Console.WriteLine(conta4.Numero_agencia);
//Console.WriteLine(conta4.Conta);


//ContaCorrente conta5 = new ContaCorrente(285, "265820-X");

//ContaCorrente conta6 = new ContaCorrente(369, "263665-X");

//Console.WriteLine(ContaCorrente.TotalDeContasCriadas);

Cliente Paola = new Cliente();
Paola.Nome = "Paola Santos";

ContaCorrente conta7 = new ContaCorrente(458,"145897-X");
conta7.Titular = Paola;
conta7.Saldo = 200;

Console.WriteLine("Titular da Conta: " + conta7.Titular.Nome);
Console.WriteLine("Saldo: R$" + conta7.Saldo);
Console.WriteLine("Total de Contas Criadas: " + ContaCorrente.TotalDeContasCriadas);

Console.ReadKey();
