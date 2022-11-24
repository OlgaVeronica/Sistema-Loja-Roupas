create database bd_loja_de_roupas;
use bd_loja_de_roupas;

create table Loja(
id_loja int primary key auto_increment,
nome_loja varchar(300), 
cnpj_loja varchar(300),
endereco_loja varchar(300)
); 

/*insert into Loja values(null, 'Lince', '111111111111', 'Rua 2 de abril, Nº157');
insert into Loja values(null, 'Ellus', '111111111111', 'Rua 2 de abril, Nº157');
insert into Loja values(null, 'IFROStore', '111111111111', 'Rua 2 de abril, Nº157');
insert into Loja values(null, 'Lince', '111111111111', 'Rua 2 de abril, Nº157');
insert into Loja values(null, 'Lince', '111111111111', 'Rua 2 de abril, Nº157');*/


create table Usuario(
id_user int primary key auto_increment,
nome_user varchar(300),
cpf_user varchar(300),
senha_user varchar(300),
tipo_user varchar(300),
avatar_user varchar(1000)
);

create table Funcionario(
id_func int primary key auto_increment,
nome_func varchar(300),
telefone_func varchar(300),
endereco_func varchar(300),
cpf_func varchar(300),
sexo_func varchar(100),
email_func varchar(300),
rg_func varchar(300),
funcao_func varchar(300),
salario_func float,
#avatar_func varchar(1000),
status_func varchar(100),
avatar_func varchar(300),
id_loja_fk int,
foreign key (id_loja_fk) references Loja(id_loja)
); #okay

create table Fornecedor(
id_forn int primary key auto_increment,
razao_social_forn varchar(300),
cnpj_forn varchar(300),
nome_fantasia_forn varchar(300),
endereco_forn varchar(300),
email_forn varchar(300),
telefone_forn varchar(300),
status_forn varchar(100)
); #okay

create table Marca(
id_mar int primary key auto_increment,
nome_mar varchar(300),
logo_mar varchar(1000),
status_mar varchar(100)
);

create table Cliente(
id_cli int primary key auto_increment,
nome_cli varchar(300), 
cpf_cli varchar(300),
telefone_cli varchar(300),
status_cli varchar(100)
); #okay

create table Venda(
id_ven int primary key auto_increment,
data_ven date,
hora_ven time, 
valor_ven float,
status_ven varchar(100),
id_func_fk int,
foreign key (id_func_fk) references Funcionario(id_func),
id_cli_fk int,
foreign key(id_cli_fk) references Cliente(id_cli)
);# n/n roupa


create table Roupa(
id_roup int primary key auto_increment,
descricao_roup varchar(300),
material_roup varchar(300),
tipo_roup varchar(300),
colecao_roup varchar(300),
tamanho_roup varchar(300),
estampa_roup varchar(300),
status_roup varchar(100),
valor_roup float,
qtd_estoque_roup int,
id_mar_fk int,
foreign key (id_mar_fk) references Marca(id_mar)
);
##n/n venda && compra 

create table Compra(
id_com int primary key auto_increment,
data_com date,
hora_com time, 
valor_com float,
status_comp varchar(100),
id_forn_fk int,
foreign key (id_forn_fk) references Fornecedor(id_forn),
id_func_fk int,
foreign key (id_func_fk) references Funcionario(id_func)
);


create table Despesa(
id_desp int primary key auto_increment,
descricao_desp varchar(300),
vencimento_desp date,
valor_desp float,
status_desp varchar(100)
);


create table Caixa(
id_cai int primary key auto_increment,
data_cai date,
numero_cai int,
hora_abertura_cai time,
hora_fechamento_cai time,
saldo_inicial_cai float, 
saldo_final_cai float,
total_entrada_cai float,
total_saida_cai float,
status_cai varchar(100)
);


create table Recebimento(
id_receb int primary key auto_increment,
data_abertura date,
data_receb date,
valor_receb float,
hora_receb time,
forma_recebimento_receb varchar(300),
status_receb varchar(100),
id_cai_fk int,
foreign key (id_cai_fk) references Caixa(id_cai),
id_ven_fk int,
foreign key (id_ven_fk) references Venda(id_ven)
);



create table Pagamento(
id_pag int primary key auto_increment,
data_pag date,
valor_pag float,
hora_pag time,
forma_recebimento_pag varchar(300),
status_pag varchar(100),
id_cai_fk int,
foreign key (id_cai_fk) references Caixa(id_cai),
id_desp_fk int,
foreign key (id_desp_fk) references Despesa(id_desp)
);


create table Venda_Roupa(
id_ven_roup int primary key auto_increment,
quantidade_ven_roup int,
id_ven_fk int,
foreign key (id_ven_fk) references Venda(id_ven),
id_roup_fk int,
foreign key (id_roup_fk) references Roupa(id_roup)
);



create table Compra_Roupa(
id_com_roup int primary key auto_increment,
quantidade_com_roup int,
id_com_fk int,
foreign key (id_com_fk) references Compra(id_com),
id_roup_fk int,
foreign key (id_roup_fk) references Roupa(id_roup)
);





DELIMITER $$
create procedure AbrirCaixa(saldoInicial float)
begin
	declare dataHoje date;
	declare horaAgora time;
    declare numeroUltimoCaixa int;
    select curdate() into dataHoje;
    select curtime() into horaAgora;
    
    if((select numero_cai from Caixa order by id_cai desc limit 1) is null) then
		set numeroUltimoCaixa = 0;
    
    else
    
		set numeroUltimoCaixa = (select numero_cai from Caixa order by id_cai desc limit 1);
    
    end if;
    
  
    insert into Caixa values(null, dataHoje, numeroUltimoCaixa+1, horaAgora, null, saldoInicial, null, null, null, 'Aberto');
    select 'Caixa Inserido com sucesso!' as Confirmacao;
end
$$ DELIMITER ;

call AbrirCaixa(100);
select * from caixa;

insert into cliente values (null, "doido", "4575", "8676", "Ativo");
insert into cliente values (null, "test", "4575", "8676", "Ativo");



DELIMITER $$
create procedure InserirLoja(nome varchar(300), cnpj varchar(300), endereco varchar(300))
begin
    if ((nome is not null) and (nome <> '')) then
        if((cnpj is not null) and (cnpj <> '')) then
            insert into Loja values(null, nome, cnpj, endereco);
            select 'Loja inserida com sucesso!' as Confirmacao;
		else
			select 'CNPJ não pode estar vazio!' as Erro;
        end if;
	else
		select 'Nome não pode estar vazio!' as Erro;
    end if;
end;
$$ DELIMITER ;

call InserirLoja("Manas", "02.954.741/0001-37", "Urias, 2341, Centro, Rondônia");
call InserirLoja("Grauna", "65.740.854/0001-50", "da Paz, 7575, Vila Nova, Pernambuco");
call InserirLoja("EasyWay", "09.652.085/0001-67", "Vinte e Quatro, 697, Centro, Sergipe");
call InserirLoja("Monumental", "56.877.729/0001-03", "Projetada, 303, São José, Alagoas");
call InserirLoja("Bahamas", "21.322.185/0001-20", "São Francisco, 4501, Industrial, Distrito Federal");
call InserirLoja("Carmen Steffen's", "34.142.252/0001-77", "Maranhão, 1059, Planalto, Mato Grosso");
call InserirLoja("Amadeus", "11.435.832/0001-57", "Vinte e Quatro, 3804, Industrial, Rio de Janeiro");
call InserirLoja("Ideal Roupas", "80.852.119/0001-21", "Vinte, 72, Industrial, São Paulo");
call InserirLoja("BigStar", "80.852.119/0001-21", "das flores, 892, Industrial, São Paulo");
call InserirLoja("Dynamic", "80.852.119/0001-21", "das camélias, 757, Industrial, São Paulo");

DELIMITER $$
create procedure AtualizarLoja(codigo int, nome varchar(300), cnpj varchar(300), endereco varchar(300))
begin
    if ((codigo is not null) and (codigo <> '')) then
        if((endereco is not null) and (endereco <> '')) then
            
            update Loja set nome_loja = nome, cnpj_loja = cnpj, endereco_loja = endereco where id_loja = codigo;
            select 'Loja atualizada com sucesso!' as Confirmacao;
		else
			select 'Endereço não pode estar vazio!' as Erro;
        end if;
	else
		select 'Código não pode estar vazio!' as Erro;
    end if;
end;
$$ DELIMITER ;

call AtualizarLoja(1, "Manas", "02.954.741/0001-37", "Urias, 2341, Centro, Rondônia");
call AtualizarLoja(2, "Grauna", "65.740.854/0001-50", "da Paz, 7575, Vila Nova, Pernambuco");
call AtualizarLoja(3, "EasyWay", "09.652.085/0001-67", "Vinte e Quatro, 697, Centro, Sergipe");
call AtualizarLoja(4, "Monumental", "56.877.729/0001-03", "Projetada, 303, São José, Alagoas");
call AtualizarLoja(5, "Bahamas", "21.322.185/0001-20", "São Francisco, 4501, Industrial, Distrito Federal");
call AtualizarLoja(6, "Carmen Steffen's", "34.142.252/0001-77", "Maranhão, 1059, Planalto, Mato Grosso");
call AtualizarLoja(7, "Amadeus", "11.435.832/0001-57", "Vinte e Quatro, 3804, Industrial, Rio de Janeiro");
call AtualizarLoja(8, "Ideal Roupas", "80.852.119/0001-21", "Vinte, 72, Industrial, São Paulo");
call AtualizarLoja(9, "BigStar", "80.852.119/0001-21", "das flores, 892, Industrial, São Paulo");
call AtualizarLoja(10, "Dynamic", "80.852.119/0001-21", "das camélias, 757, Industrial, São Paulo");

DELIMITER $$
create procedure InserirFuncionario(
	nome varchar(300), 
	telefone varchar(300), 
	endereco varchar(300), 
	cpf varchar(300),
    sexo varchar(300),
    email varchar(300),
    rg varchar(300),
    funcao varchar(300),
    salario float,
    avatar varchar(300),
    status varchar(100),
    lojaFK int)
begin
	if ((nome is not null) and (nome <> '')) then
		if((cpf is not null) and (cpf <> '')) then
			insert into Funcionario values(null, nome, telefone, endereco, cpf, 
            sexo, email, rg, funcao, salario, avatar, status, lojaFK);
			select 'Funcionário inserido com sucesso!' as Confirmacao;
		else
			select 'CPF inválido' as Erro;
		end if;
	else
		select 'Nome não pode ser nulo ou vazio' as Erro;
    end if;
end
$$ DELIMITER ;



call InserirFuncionario("Maria", "(69) 9999-9999", "Rua João de Oliveira", "000.000.000-00", "Feminino", "maria@gmail.com", "000.000", "Vendas", 1800, null,  "ativo",1);
call InserirFuncionario("Urias", "(69) 9999-9999", "Rua João de Oliveira", "000.000.000-00", "Feminino", "urias@gmail.com", "000.000", "Caixa", 2300, null,  "ativo", 1);
call InserirFuncionario("Beca", "(69) 9999-9999", "Rua João de Oliveira", "000.000.000-00", "Feminino", "beca@gmail.com", "000.000", "Limpeza", 1400, null,  "ativo", 1);
call InserirFuncionario("Catia", "(69) 9999-9999", "Rua João de Oliveira", "000.000.000-00", "Feminino", "catiaa@gmail.com", "000.000", "Atendimento", 1800, null,  "ativo", 1);
call InserirFuncionario("Fernanda", "(69) 9999-9999", "Rua João de Oliveira", "000.000.000-00", "Feminino", "fernandaa@gmail.com", "000.000", "Caixa", 2300, null,  "ativo", 1);
call InserirFuncionario("Gabriela", "(69) 9999-9999", "Rua João de Oliveira", "000.000.000-00", "Feminino", "maria@gmail.com", "000.000", "Vendas", 1800, null,  "ativo",1);
call InserirFuncionario("Jania", "(69) 9999-9999", "Rua João de Oliveira", "000.000.000-00", "Feminino", "urias@gmail.com", "000.000", "Caixa", 2300, null,  "ativo", 1);
call InserirFuncionario("Vitoria", "(69) 9999-9999", "Rua João de Oliveira", "000.000.000-00", "Feminino", "beca@gmail.com", "000.000", "Limpeza", 1400, null,  "ativo", 1);
call InserirFuncionario("Patricia", "(69) 9999-9999", "Rua João de Oliveira", "000.000.000-00", "Feminino", "catiaa@gmail.com", "000.000", "Atendimento", 1800, null,  "ativo", 1);
call InserirFuncionario("Samara", "(69) 9999-9999", "Rua João de Oliveira", "000.000.000-00", "Feminino", "fernandaa@gmail.com", "000.000", "Caixa", 2300, null,  "ativo", 1);


DELIMITER $$
create procedure AtualizarFuncionario(
	codigo int,
	nome varchar(300), 
	telefone varchar(300), 
	endereco varchar(300), 
	cpf varchar(300),
    sexo varchar(300),
    email varchar(300),
    rg varchar(300),
    funcao varchar(300),
    salario float,
    avatar varchar(300),
    status varchar(100),
    lojaFK int)
begin

	if ((nome is not null) and (nome <> '')) then
		if((cpf is not null) and (cpf <> '')) then
			update Funcionario set 
			nome_func = nome, 
			telefone_func = telefone, 
            endereco_func = endereco,
			cpf_func = cpf, 
			sexo_func = sexo, 
			email_func = email, 
			rg_func = rg, 
			funcao_func = funcao, 
			salario_func = salario, 
			avatar_func = avatar, 
			status_func = status,
			id_loja_fk = lojaFK
			
			where id_func = codigo;
			
			select 'Funcionário atualizado com sucesso!' as Confirmacao;
		else 
			select 'CPF inválido' as Erro;
		end if;
	else
		select 'Nome não pode ser nulo ou vazio' as Erro;
	end if;
end
$$ DELIMITER ;


call AtualizarFuncionario(1,"Maria Eduarda", "(69) 6969-6969", "Rua João de Oliveira", "000.000.000-00", "Feminino", "maria@gmail.com", "000.111", "Gerente", 5000, "C:\Users\2020102011008-1\Downloads\P_20210406_081110.jpg","ativo",1);
call AtualizarFuncionario(2, "Urias", "(69) 99426-5056", "Rua Tenente-Coronel Cardoso", "000.000.000-00", "Feminino", "urias@gmail.com", "000.222", "Caixa", 2300, null,  "ativo", 1);
call AtualizarFuncionario(3, "Beca", "(69) 99366-8565", "Rua Domingos Olímpio", "000.000.000-00", "Feminino", "beca@gmail.com", "000.333", "Limpeza", 1400, null,  "ativo", 1);
call AtualizarFuncionario(4, "Catia", "(69) 97486-4855", "Avenida Esbertalina Barbosa Damiani", "000.000.000-00", "Feminino", "catiaa@gmail.com", "000.444", "Atendimento", 1800, null,  "ativo", 1);
call AtualizarFuncionario(5, "Fernanda", "(69) 97428-1441", "Avenida Afonso Pena", "000.000.000-00", "Feminino", "fernandaa@gmail.com", "000.555", "Caixa", 2300, null,  "ativo", 1);
call AtualizarFuncionario(6, "Gabriela", "(69) 99212-8553", "Vila Nova", "000.000.000-00", "Feminino", "gabriela@gmail", "00.666", "Atendimento", 1800, null, "ativo", 1);
call AtualizarFuncionario(7, "Jania", "(69) 99104-4521", "São Cristóvão", "000.000.000-00", "Feminino", "jania@gmail", "00.777", "Caixa", 2300, null, "ativo", 1);
call AtualizarFuncionario(8, "Vitoria", "(69) 99356-7607", "Industrial", "000.000.000-00", "Feminino", "vitoria@gmail", "00.888", "Atendimento", 2300, null, "ativo", 1);
call AtualizarFuncionario(9, "Patricia", "(69) 97386-4482", "São Jorge", "000.000.000-00", "Feminino", "patricia@gmail", "00.999", "Limpeza", 1300, null, "ativo", 1);
call AtualizarFuncionario(10, "Samara", "(69) 97494-8778", "Sergipe", "000.000.000-00", "Feminino", "samara@gmail", "00.000", "Atendimento", 1800, null, "ativo", 1);

DELIMITER $$
create procedure InserirFornecedor(
	razaoSocial varchar(300), 
	cnpj varchar(300), 
    nomeFantasia varchar(300),
    endereco varchar(300),
    email varchar(300),
    telefone varchar(300),
    status varchar(100))
begin

	if((razaoSocial is not null) and (razaoSocial <> '')) then
		if((cnpj is not null) and (cnpj <> '')) then
			insert into Fornecedor values(null, razaoSocial, cnpj,
            nomeFantasia, endereco, email, telefone, status);
			select 'Fornecedor inserido com sucesso!' as Confirmacao;
        else
			select 'CNPJ inválido' as Erro;
		end if;
	else
		select 'Razão Social inválida' as Erro;
    end if;
end
$$ DELIMITER ;

call InserirFornecedor("Rosângela e Lara Telas Ltda", "52.501.698/0001-22", "RosaLau Ltda", "Rua Itapicuru 837", "contabil@rosangelaelaratelasltda.com.br", "(11) 3785-6790", "Ativo");
call InserirFornecedor("Chinelos Universo Ltda", "52.501.698/0001-22", "Chinelos Ltda", "Rua Itapicuru 837", "chinelos@chinelouniversoltda.com.br", "(11) 3785-6790", "Ativo");
call InserirFornecedor("Carlos e Heloisa Marketing Ltda", "52.501.698/0001-22", "Flores Lindas Ltda", "Rua Itapicuru 837", "marketin@carlosheloltda.com.br", "(11) 3785-6790", "Ativo");
call InserirFornecedor("Lucas e Juliana Transportes Ltda", "52.501.698/0001-22", "Lucas Transportes Ltda", "Rua Itapicuru 837", "Lucas@TransportadoraLucasltda.com.br", "(11) 3785-6790", "Ativo");
call InserirFornecedor("Levi e Sara acompanhamento financeiro ME", "52.501.698/0001-22", "SaVi Acompanhamento Financeiro Ltda", "Rua Itapicuru 837", "contabil@contabilidadeltda.com.br", "(11) 3785-6790", "Ativo");


DELIMITER $$
create procedure AtualizarFornecedor(
	codigo int,
	razaoSocial varchar(300), 
	cnpj varchar(300), 
    nomeFantasia varchar(300),
    endereco varchar(300),
    email varchar(300),
    telefone varchar(300),
    status varchar(100))
begin
	if((razaoSocial is not null) and (razaoSocial <> '')) then
		if((cnpj is not null) and (cnpj <> '')) then
			update Fornecedor set
			razao_social_forn = razaoSocial, 
			cnpj_forn = cnpj, 
			nome_fantasia_forn = nomeFantasia, 
			endereco_forn = endereco, 
			email_forn = email, 
			status_forn = status
			
			where id_forn = codigo;
			
			select 'Fornecedor Atualizado com sucesso!' as Confirmacao;
            
		else
            select 'CNPJ inválido' as Erro;
		end if;
	else
		select 'Razão Social inválida' as Erro;
    end if;
end
$$ DELIMITER ;

call AtualizarFornecedor(1, "Rosângela e Lara Telas Ltda", "52.501.698/0001-22", "RoLa Ltda", "Rua Itapicuru 837", "contabil@rosangelaelaratelasltda.com.br", "(11) 3785-6790", "desativado");
call AtualizarFornecedor(2, "Chinelos Universo Ltda", "43.431.736/0001-27", "CU Ltda", "Rua Itapicuru 837", "chinelos@chinelouniversoltda.com.br", "(69) 99269-7201", "Ativo");
call AtualizarFornecedor(3, "Carlos e Heloisa Marketing Ltda", "44.524.791/0001-24", "Flores Lindas Ltda", "Rua Itapicuru 837", "marketin@carlosheloltda.com.br", "(69) 96825-2416", "Ativo");
call AtualizarFornecedor(4, "Lucas e Juliana Transportes Ltda", "55.664.846/0001-18", "Lucas Trans Ltda", "Rua Itapicuru 837", "Lucas@TransportadoraLucasltda.com.br", "(69) 99386-1368", "Ativo");
call AtualizarFornecedor(5, "Levi e Sara acompanhamento financeiro ME", "97.385.425/0001-06", "ADMLiberado Ltda", "Rua Itapicuru 837", "contabil@contabilidadeltda.com.br", "(69) 97631-2255", "Ativo");


DELIMITER $$
create procedure InserirMarca(nome varchar(300), logo longblob, status varchar(100))
begin

	if((nome is not null) and (nome <> '')) then
		if((status is not null) and (status <> '')) then
			insert into Marca values(null, nome, logo, status);
			select 'Marca inserida com sucesso!' as Confirmacao;
            
		else 
			select concat('Defina o status da marca'+nome) as Erro;
		end if;
	else
		select 'Nome inválido. Insira um nome válido para marca.' as Erro;
	end if;
end
$$ DELIMITER ;

call InserirMarca ("Hering", null, "Ativo");
call InserirMarca ("Nike", null, "Ativo");
call InserirMarca ("H&H", null, "Ativo");
call InserirMarca ("Zara", null, "Ativo");
call InserirMarca ("Louis Vuitton", null, "Ativo");
call InserirMarca ("Adidas", null, "Ativo");
call InserirMarca ("Gucci", null, "Ativo");
call InserirMarca ("Hermes", null, "Ativo");
call InserirMarca ("Lacoste", null, "Ativo");
call InserirMarca ("Levi's", null, "Ativo");
call InserirMarca ("Malwee", null, "Ativo");


DELIMITER $$
create procedure AtualizarMarca(codigo int, nome varchar(300), logo longblob, status varchar(100))
begin
	if((nome is not null) and (nome <> '')) then
		if((status is not null) and (status <> '')) then
			update Marca set
			nome_mar = nome, 
			logo_mar = logo, 
			status_mar = status
			
			where id_mar = codigo;
			
			select 'Marca atualizada com sucesso!' as Confirmacao;
		else
			select 'Defina o status da marca.' as Erro;
		end if;
	else
		select 'Nome inválido. Insira um nome válido para marca.' as Erro;
	end if;
end
$$ DELIMITER ;

call AtualizarMarca (1, "Hering", null, "Ativo");
call AtualizarMarca (2, "Nike", null, "Ativo");
call AtualizarMarca (3, "H&H", null, "Ativo");
call AtualizarMarca (4, "Zara", null, "Ativo");
call AtualizarMarca (5, "Louis Vuitton", null, "Ativo");
call AtualizarMarca (6, "Adidas", null, "Ativo");
call AtualizarMarca (7, "Gucci", null, "Ativo");
call AtualizarMarca (8, "Hermes", null, "Ativo");
call AtualizarMarca (9,"Lacoste", null, "Ativo");
call AtualizarMarca (11, "Levi's", null, "Ativo");
call AtualizarMarca (12, "Malwee", null, "Ativo");

DELIMITER $$
create procedure InserirCliente(nome varchar(300), cpf varchar(300), telefone varchar(300), status varchar(100))
begin
	if((nome is not null) and (nome <> '')) then
		if((cpf is not null) and (cpf <> '')) then
			insert into Cliente values (null, nome, cpf, telefone, status);
			select 'Cliente inserido com sucesso!' as Confirmacao;
		else
			select 'Insira um CPF válido.' as Erro;
		end if;
	else
		select 'Nome não pode ser nulo ou vazio.' as Erro;
	end if;
end
$$ DELIMITER ;

call InserirCliente ("Eloizy Campi", "987.654.321-00", "(69) 99292-9292", "Ativo");
call InserirCliente ("Samuel Felipe", "987.654.321-00", "(69) 99292-9292", "Ativo");
call InserirCliente ("Patrick Macedo", "987.654.321-00", "(69) 99292-9292", "Ativo");
call InserirCliente ("Maria Eduarda", "987.654.321-00", "(69) 99292-9292", "Ativo");
call InserirCliente ("Olga Veronica", "987.654.321-00", "(69) 99292-9292", "Ativo");
call InserirCliente ("Gabriel Oliveira", "987.654.321-00", "(69) 99292-9292", "Ativo");
call InserirCliente ("Antônio Palauro", "987.654.321-00", "(69) 99292-9292", "Ativo");
call InserirCliente ("Wallyson Torres", "987.654.321-00", "(69) 99292-9292", "Ativo");
call InserirCliente ("Luana Freire", "987.654.321-00", "(69) 99292-9292", "Ativo");
call InserirCliente ("Urias Lopes", "987.654.321-00", "(69) 99292-9292", "Ativo");

DELIMITER $$
create procedure AtualizarCliente(codigo int, nome varchar(300), cpf varchar(300), telefone varchar(300), status varchar(100))
begin
	if((nome is not null) and (nome <> '')) then
		if((cpf is not null) and (cpf <> '')) then
			update Cliente set
			nome_cli = nome, 
			cpf_cli = cpf, 
			telefone_cli = telefone, 
			status_cli = status
			
			where id_cli = codigo;
			
			select 'Cliente atualizado com sucesso!' as Confirmacao;
		else
			select 'CPF inválido' as Erro;
           end if;
	else
		select 'Nome não pode ser nulo ou vazio.' as Erro;
	end if;
end
$$ DELIMITER ;

call AtualizarCliente (1, "Eloizy Campi", "987.654.321-00", "(69) 99292-9292", "Ativo");
call AtualizarCliente (2, "Samuel Felipe", "022.205.183-37", "(69) 96870-7467", "Ativo");
call AtualizarCliente (3, "Patrick Macedo", "011.425.237-80", "(69) 99458-7515", "Ativo");
call AtualizarCliente (4, "Maria Eduarda", "111.115.387-60", "(69) 97382-1728", "Ativo");
call AtualizarCliente (5, "Olga Veronica", "011.304.448-80", "(69) 97434-8631", "Ativo");
call AtualizarCliente (6, "Gabriel Oliveira", "121.442.233-00", "(69) 97486-3262", "Ativo");
call AtualizarCliente (7, "Vitor Saiter", "022.114.554-09", "(69) 99165-6265", "Ativo");
call AtualizarCliente (8, "José Vinicius Passos", "023.123.434-10", "(69) 97654-1859", "Ativo");
call AtualizarCliente (9, "Luana Freire", "111.112.110-94", "(69) 96807-3150", "Ativo");
call AtualizarCliente (10, "Urias Lopes", "102.403.475-52", "(69) 97354-1256", "Ativo");


DELIMITER $$
create procedure InserirVenda(data date, hora time, valor float, status varchar(100), funcionarioFK int, clienteFK int)
begin
	if((valor is not null) and (valor <> '')) then
		if((funcionarioFK is not null) and (funcionarioFK <> '')) then
			if((clienteFK is not null) and (clienteFK <> '')) then
				insert into Venda values(null, data, hora, valor, status, funcionarioFK, clienteFK);
					select 'Venda inserida com sucesso!' as Confirmacao;
                else
					select 'Informe um cliente válido.' as Erro;
                end if;
			else
				select 'Informe um funcionario válido.' as Erro;
            end if;
		else
			select 'Venda zerada. Informe um valor válido.' as Erro;
        end if;
end
$$ DELIMITER ;

call InserirVenda("2022-11-21", "13:27:00", 1015, "Pago", 1, 1);

DELIMITER $$
create procedure AtualizarVenda(codigo int, data date, hora time, valor float, status varchar(100), funcionarioFK int, clienteFK int)
begin
	if((valor is not null) and (valor <> '')) then
			if((funcionarioFK is not null) and (funcionarioFK <> '')) then
				if((clienteFK is not null) and (clienteFK <> '')) then
					update Venda set
					data_ven = data, 
					hora_ven = hora, 
					valor_ven = valor, 
					status_ven = status, 
					id_func_fk = funcionarioFK, 
					id_cli_fk = clienteFK
					
					where id_ven = codigo;
					select 'Venda atualizada com sucesso!' as Confirmacao;
                    
                    else
					select 'Informe um cliente válido.' as Erro;
                end if;
			else
				select 'Informe um funcionario válido.' as Erro;
            end if;
		else
			select 'Venda zerada. Informe um valor válido.' as Erro;
        end if;
end
$$ DELIMITER ;

call AtualizarVenda (1,"2022-11-21", "13:27:00", 1015, "Não pago", 1, 1);

DELIMITER $$
create procedure InserirRoupa(
	descricao varchar(300),
    material varchar(300),
    tipo varchar(300),
    colecao varchar(300),
    tamanho varchar (300),
    estampa varchar(300),
    status varchar(100),
    valor float,
    qtdEstoque int,
    marcaFK int)
begin
	if((descricao is not null) and (descricao <> '')) then
		if((valor is not null) and (valor <> '')) then
			if((marcaFK is not null) and (marcaFK <> '')) then
				insert into Roupa values(null,descricao, material, tipo, colecao, tamanho, estampa, status, valor, qtdEstoque,  marcaFK);
					select 'Roupa inserida com sucesso!' as Confirmacao;
			
            else
				select 'Informe a marca da roupa.' as Erro;
            end if;
		else
			select 'Informe o valor da roupa.' as Erro;
        end if;
	else
		select 'Informe a descrição da roupa.' as Erro;
	end if;
end
$$ DELIMITER ;

call InserirRoupa("Casaco para frio","Moletom","Casaco", "Inverno", "Único", "Cinza","Disponível", 180.99, 10, 1);


DELIMITER $$
create procedure AtualizarRoupa(
	codigo int,
	descricao varchar(300),
    material varchar(300),
    tipo varchar(300),
    colecao varchar(300),
    tamanho varchar (300),
    estampa varchar(300),
    status varchar(100),
    valor float,
    qtdEstoque int,
    marcaFK int)
begin
	if((descricao is not null) and (descricao <> '')) then
		if((valor is not null) and (valor <> '')) then
			if((marcaFK is not null) and (marcaFK <> '')) then
				update Roupa set 
				descricao_roup = descricao, 
				material_roup = material, 
				tipo_roup = tipo, 
				colecao_roup = colecao, 
				tamanho_roup = tamanho,
				estampa_roup = estampa, 
				status_roup = status, 
				valor_roup = valor, 
                qtd_estoque_roup = qtdEstoque,
				id_mar_fk = marcaFK
				
				where id_roup = codigo;
				select 'Roupa atualizada com sucesso!' as Confirmacao;
                
			else
				select 'Informe a marca da roupa.' as Erro;
            end if;
		else
			select 'Informe o valor da roupa.' as Erro;
        end if;
	else
		select 'Informe a descrição da roupa.' as Erro;
	end if;
end
$$ DELIMITER ;

call AtualizarRoupa(1,"Casaco para frio","Moletom","Casaco", "Outono/Inverno", "P, M, G, EG", "Cinza","Disponível", 180.99, 3, 1);


DELIMITER $$
create procedure InserirCompra(data date, hora time, valor float, status varchar(100), fornecedorFK int, funcionarioFK int)
begin
	if((valor is not null) and (valor <> '')) then
			if((fornecedorFK is not null) and (fornecedorFK <> '')) then
				if((funcionarioFK is not null) and (funcionarioFK <> '')) then
					insert into Compra values(null, data, hora, valor, status, fornecedorFK, funcionarioFK);
					select 'Compra inserida com sucesso!' as Confirmacao;
                    
                    else
						select 'Informe o funcionário que realizará a compra!' as Erro;
				end if;
                else
					select 'Informe o fornecedor da compra!' as Erro;
			end if;
            else
				select 'Informe o valor da compra!' as Erro;
	end if;
end
$$ DELIMITER ;
call inserircompra("2022-10-29","16:30:00", 60, "Pago", 1,1);

DELIMITER $$
create procedure AtualizarCompra(codigo int, data date, hora time, valor float, status varchar(100), fornecedorFK int, funcionarioFK int)
begin
	if((valor is not null) and (valor <> '')) then
			if((fornecedorFK is not null) and (fornecedorFK <> '')) then
				if((funcionarioFK is not null) and (funcionarioFK <> '')) then
					update Compra set
					data_com = data, 
					hora_com = hora, 
					valor_com = valor, 
					status_com = status, 
					id_forn_fk = fornecedorFK, 
					id_func_fk = funcionarioFK
					
					where id_com = codigo;
					
					select 'Compra atualizada com sucesso!' as Confirmacao;
                    
                    else
						select 'Informe o funcionário que realizará a compra!' as Erro;
				end if;
                else
					select 'Informe o fornecedor da compra!' as Erro;
			end if;
            else
				select 'Informe o valor da compra!' as Erro;
	end if;
end
$$ DELIMITER ;


alter table compra change status_comp status_com varchar(100);
call AtualizarCompra(1,"2022-10-29","16:30:00", 120, "Aberto", 1,1);


DELIMITER $$
create procedure InserirDespesa(descricao varchar(300), vencimento date, valor float, status varchar(100), compraFK int)
begin
	if((valor is not null) and (valor <> '')) then
			if((descricao is not null) and (descricao <> '')) then
				if((compraFK is not null) and (compraFK <> '')) then
					insert into Despesa values(null, descricao, vencimento, valor, status, compraFK);
					select 'Despesa inserida com sucesso!' as Confirmacao;
                    
                    else
						select 'Informe a compra que gerou a despesa!' as Erro;
				end if;
            else
				select 'Informe a descrição da despesa!' as Erro;
			end if;
	else
		select 'Informe o valor da compra!' as Erro;
	end if;
end
$$ DELIMITER ;

call inserirdespesa("Compra de produtos de limpeza","2022-10-29", 2000, "Aberto",1);


################ a partir daqui

DELIMITER $$
create procedure AtualizarDespesa(codigo int, descricao varchar(300), vencimento date, valor float, status varchar(100), compraFK int)
begin
	if((descricao <> "") and (descricao is not null)) then
		if((valor <> "") and (valor is not null)) then
			if((compraFK <> "") and (compraFK is not null)) then
				update Despesa set 
				descricao_desp = descricao, 
				vencimento_desp = vencimento, 
				valor_desp = valor,
				status_desp = status, 
				id_com_fk = compraFK
						
				where id_desp = codigo;
                
                select 'Despesa atualizada com sucesso!' as Confirmacao;

			else
				select "Informe a compra que gerou a despesa!" as Erro;
			end if;
		else
			select "Informe o valor da compra!" as Erro;
		end if;
	else
		select 'Informe a descrição da despesa!' as Erro;
    end if;
end
$$ DELIMITER ;


call atualizardespesa(1, "", "2022-10-28", 2000, "Aberto", 1);


DELIMITER $$
create procedure InserirCaixa(data date, numero int, horaAbertura time, horaFechamento time, saldoInicial float, saldoFinal float, totalEntrada float, totalSaida float, status varchar(100))
begin
	if (data is not null) then
		if(horaAbertura is not null) then
			if(saldoInicial is not null) then
				insert into Caixa values(null, data, numero, horaAbertura, horaFechamento, saldoInicial, saldoFinal);
				select 'Caixa inserido com sucesso!' as Confirmacao;
			else
				select "Informe o saldo inicial!" as Erro;
            end if;
		else
			select "Informe a hora de abertura!" as Erro;
        end if;
	else
		select "Informe a data!" as Erro;
    end if;
end
$$ DELIMITER ;



#call InserirCaixa("2022-11-10", 301, "17:00:00", "18:00:00", 10000, 20000);


DELIMITER $$
create procedure AtualizarCaixa(codigo int, data date, numero int, horaAbertura time, horaFechamento time, saldoInicial float, saldoFinal float, totalEntrada float, totalSaida float, status varchar(100))
begin
	if (data is not null) then
		if(horaAbertura is not null) then
			if(saldoInicial is not null) then
				update Caixa set
				data_cai = data, 
				hora_abertura_cai = horaAbertura, 
				hora_fechamento_cai = horaFechamento, 
				saldo_inicial_cai = saldoInicial, 
				saldo_final_cai = saldoFinal,
				numero_cai = numero,
                total_entrada_cai = totalEntrada,
                totalSaida_cai = totalSaida,
                status_cai = status
				where id_cai = codigo;
                
				select 'Caixa atualizada com sucesso!' as Confirmacao;
			else
				select "Informe o saldo inicial!" as Erro;
            end if;
		else
			select "Informe a hora de abertura!" as Erro;
        end if;
	else
		select "Informe a data!" as Erro;
    end if;
end
$$ DELIMITER ;

#call AtualizarCaixa(1, "2020-12-21",302, "17:00:00", "18:00:00", 10000, 20000);


DELIMITER $$
create procedure InserirRecebimento(
	dataAbertura date, 
    dataReceb date,
    valor float, 
    hora time, 
    formaRecebimento varchar(300), 
    status varchar(100),
    caixaFK int, 
    vendaFK int)
begin
	if(dataAbertura is not null) then
		if(caixaFK is not null) then
			if(vendaFK is not null) then
				insert into Recebimento values(null, dataAbertura, dataReceb, valor, hora, formaRecebimento, status, caixaFK, vendaFK);
				select 'Recebimento inserido com sucesso!' as Confirmacao;
			else
				select "Informe o código da venda!" as Erro;
            end if;
		else
			select "Informe o código da caixa!" as Erro;
		end if;
	else
		select "Informe a data!" as Erro;
    end if;
end
$$ DELIMITER ;

#call inserirRecebimento("2022-12-01", "2022-12-01" ,239, "12:00", "cartão", "Aberto", 1, 1);

DELIMITER $$
create procedure AtualizarRecebimento(
	codigo int,
	dataAbertura date, 
    dataReceb date,
    valor float, 
    hora time, 
    formaRecebimento varchar(300), 
    status varchar(100),
    caixaFK int, 
    vendaFK int)
begin

	if(dataAbertura is not null) then
		if(caixaFK is not null) then
			if(vendaFK is not null) then
				update Recebimento set
                data_abertura = dataAbertura,
				data_receb = dataReceb, 
				valor_receb = valor, 
				hora_receb = hora, 
				forma_recebimento_receb = formaRecebimento, 
				status_receb = status, 
				id_cai_fk = caixaFK, 
				id_ven_fk = vendaFK
    
				where id_receb = codigo;
    
				select 'Recebimento atualizado com sucesso!' as Confirmacao;
                
                else
				select "Informe o código da venda!" as Erro;
            end if;
		else
			select "Informe o código da caixa!" as Erro;
		end if;
	else
		select "Informe a data!" as Erro;
    end if;
end
$$ DELIMITER ;

#call atualizarRecebimento(1, "2022-12-01","2022-12-01", 239, "12:00", "cartão", "Aberto", 1, 1);


DELIMITER $$
create procedure InserirPagamento(
	data date, 
    valor float,  
    hora time, 
    formaRecebimento varchar(300), 
    status varchar(100), 	
    caixaFK int,
    despesaFK int)
begin
	if(valor is not null) then
		if(caixaFK is not null) then
			if(despesaFK is not null) then
				insert into Pagamento values(null, data, valor, hora, formaRecebimento, status, caixaFK, despesaFK);
				select 'Pagamento inserido com sucesso!' as Confirmacao;
			else
				select "Informe o código da despesa!" as Erro;
            end if;
        else
			select "Informe o código do caixa!" as Erro;
        end if;
    else
		select "Informe o valor do Pagamento!" as Erro;
    end if;
end
$$ DELIMITER ;
#call inserirPagamento("2022-10-11", 2000, "12:00", "Cartão", "fechado", 1, 1); 

DELIMITER $$
create procedure AtualizarPagamento(
	codigo int,
	data date, 
    valor float,  
    hora time, 
    formaRecebimento varchar(300), 
    status varchar(100),
    caixaFK int,
    despesaFK int)
begin
	if(valor is not null) then
		if(caixaFK is not null) then
			if(despesaFK is not null) then
				update Pagamento set 
				data_pag = data, 
				valor_pag = valor, 
				hora_pag = hora, 
				forma_recebimento_pag = formaRecebimento, 
				status_pag = status, 
				id_cai_fk = caixaFK, 
				id_desp_fk = despesaFK
				
				where id_pag = codigo;
				
				select 'Pagamento atualizado com sucesso!' as Confirmacao;
			else
				select "Informe o código da despesa!" as Erro;
            end if;
        else
			select "Informe o código do caixa!" as Erro;
        end if;
    else
		select "Informe o valor do Pagamento!" as Erro;
    end if;
end
$$ DELIMITER ;

#call atualizarPagamento(1, "2022-10-11", 2000, "12:00", "Cartão", "fechado", 1, 1); 


DELIMITER $$
create procedure InserirVendaRoupa(quantidade int, vendaFK int, roupaFK int)
begin
	if((quantidade > 0) and (quantidade is not null)) then
		if(vendaFK is not null) then
			if(roupaFK is not null) then
				insert into VendaRoupa values(null, quantidade, vendaFK, roupaFK);
				select 'Venda Roupa inserido com sucesso!' as Confirmacao;
			else
				select "Informe o código da roupa!" as Erro;
            end if;
		else
			select "Informe o código da venda!" as Erro;
		end if;
	else
		select "A quantidade tem que ser um número maior que 0!" as Erro;
    end if;
end
$$ DELIMITER ;

DELIMITER $$
create procedure AtualizarVendaRoupa(codigo int, quantidade int, vendaFK int, roupaFK int)
begin
if((quantidade > 0) and (quantidade is not null)) then
		if(vendaFK is not null) then
			if(roupaFK is not null) then
				update VendaRoupa set 
				quantidade_ven_roup =  quantidade, 
				id_ven_fk = vendaFK, 
				id_roup_fk = roupaFK
				
				where id_ven_roup = codigo;
    
				select 'Venda Roupa atualizado com sucesso!' as Confirmacao;
                else
				select "Informe o código da roupa!" as Erro;
            end if;
		else
			select "Informe o código da venda!" as Erro;
		end if;
	else
		select "A quantidade tem que ser um número maior que 0!" as Erro;
    end if;
end
$$ DELIMITER ;



DELIMITER $$
create procedure InserirCompraRoupa(quantidade int, compraFK int, roupaFK int)
begin
	if((quantidade > 0) and (quantidade is not null)) then
		if(compraFK is not null) then
			if(roupaFK is not null) then
				insert into CompraRoupa values(null, quantidade, compraFK, roupaFK);
				select 'Compra Roupa inserido com sucesso!' as Confirmacao;
			else
				select "Informe o código da roupa!" as Erro;
            end if;
		else
			select "Informe o código da compra!" as Erro;
		end if;
	else
		select "A quantidade tem que ser um número maior que 0!" as Erro;
    end if;
end
$$ DELIMITER ;

DELIMITER $$
create procedure AtualizarCompraRoupa(codigo int, quantidade int, compraFK int, roupaFK int)
begin
	if((quantidade > 0) and (quantidade is not null)) then
		if(compraFK is not null) then
			if(roupaFK is not null) then
				update CompraRoupa set 
				quantidade_com_roup = quantidade, 
				id_com_fk = compraFK, 
				id_roup_fk = roupaFK
				
				where id_comp = codigo;
				
				select 'Compra Roupa atualizado com sucesso!' as Confirmacao;
			else
				select "Informe o código da roupa!" as Erro;
            end if;
		else
			select "Informe o código da compra!" as Erro;
		end if;
	else
		select "A quantidade tem que ser um número maior que 0!" as Erro;
    end if;
end
$$ DELIMITER ;