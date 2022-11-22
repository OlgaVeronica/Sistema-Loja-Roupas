create database bd_loja_de_roupas;
use bd_loja_de_roupas;

create table Loja(
id_loja int primary key auto_increment,
nome_loja varchar(300), 
cnpj_loja varchar(300),
endereco_loja varchar(300)
); 

insert into Loja values(null, 'Lince', '111111111111', 'Rua 2 de abril, Nº157');
insert into Loja values(null, 'Ellus', '111111111111', 'Rua 2 de abril, Nº157');
insert into Loja values(null, 'IFROStore', '111111111111', 'Rua 2 de abril, Nº157');
insert into Loja values(null, 'Lince', '111111111111', 'Rua 2 de abril, Nº157');
insert into Loja values(null, 'Lince', '111111111111', 'Rua 2 de abril, Nº157');


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

select * from funcionario ;
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
select * from marca;
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
status_desp varchar(100),
id_com_fk int,
foreign key (id_com_fk) references Compra(id_com) 
);


create table Caixa(
id_cai int primary key auto_increment,
data_cai date,
hora_abertura_cai time,
hora_fechamento_cai time,
saldo_inicial_cai float, 
saldo_final_cai float
);


create table Recebimento(
id_receb int primary key auto_increment,
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

select * from loja;

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

select * from venda;
select * from compra;

create table Compra_Roupa(
id_com_roup int primary key auto_increment,
quantidade_com_roup int,
id_com_fk int,
foreign key (id_com_fk) references Compra(id_com),
id_roup_fk int,
foreign key (id_roup_fk) references Roupa(id_roup)
);

insert into cliente values (null, "doido", "4575", "8676", "Ativo");
insert into cliente values (null, "test", "4575", "8676", "Ativo");
select*from funcionario;
select*from cliente;

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

call InserirLoja("Manas", "000000", "Centro");
call InserirLoja("Grauna", "000000", "");

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
select*from loja;
call AtualizarLoja(1, "Lince","111111111111", "COHAB");

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
    -- avatar longblob,
    status varchar(100),
    lojaFK int)
begin
	if ((nome is not null) and (nome <> '')) then
		if((cpf is not null) and (cpf <> '')) then
			insert into Funcionario values(null, nome, telefone, endereco, cpf, 
            sexo, email, rg, funcao, salario, /*avatar,*/ status, lojaFK);
			select 'Funcionário inserido com sucesso!' as Confirmacao;
		else
			select 'CPF inválido' as Erro;
		end if;
	else
		select 'Nome não pode ser nulo ou vazio' as Erro;
    end if;
end
$$ DELIMITER ;

select qtd_estoque_roup from roupa where (id_roup = 1);

call InserirFuncionario("Maria", "(69) 9999-9999", "Rua João de Oliveira", "000.000.000-00",
"Feminino", "maria@gmail.com", "000.000", "Vendedora", 1800, "ativo",1);
select*from loja;

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
    -- avatar longblob,
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
			-- avatar_func = avatar, 
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
select*from funcionario;

call AtualizarFuncionario(1,"Maria Eduarda", "(69) 6969-6969", "Rua João de Oliveira", "000.000.000-00",
"Feminino", "maria@gmail.com", "000.111", "Gerente", 5000, "ativo",1);

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

call InserirFornecedor("Rosângela e Lara Telas Ltda", "52.501.698/0001-22",
"RoLa Ltda", "Rua Itapicuru 837", "contabil@rosangelaelaratelasltda.com.br", "(11) 3785-6790", "Ativo");


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

call AtualizarFornecedor(1,"Rosângela e Lara Telas Ltda", "52.501.698/0001-22",
"RoLa Telas Ltda", "Rua Itapicuru 837", "contabil@rosangelaelaratelasltda.com.br", "(11) 3785-6790", "Desativado");
select*from fornecedor;

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

select*from marca;
call AtualizarMarca (1, "Hering", null, "Ativo");

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

call AtualizarCliente (1,"Eloizy Campi Reis", "987.654.321-00", "(69) 99292-6969", "Ativo");


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
    marcaFK int)
begin
	if((descricao is not null) and (descricao <> '')) then
		if((valor is not null) and (valor <> '')) then
			if((marcaFK is not null) and (marcaFK <> '')) then
				insert into Roupa values(null,descricao, material, tipo, colecao, tamanho, estampa, status, valor, marcaFK);
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

call InserirRoupa("Casaco para frio","Moletom","Casaco", "Inverno", "Único", "Cinza","Disponível", 180.99,1);


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

call AtualizarRoupa(1,"Casaco para frio","Moletom","Casaco", "Outono/Inverno", "P, M, G, EG", "Cinza","Disponível", 180.99,1);


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
select*from compra;

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

select*from despesa;
call atualizardespesa(1, "", "2022-10-28", 2000, "Aberto", 1);


DELIMITER $$
create procedure InserirCaixa(data date, horaAbertura time, horaFechamento time, saldoInicial float, saldoFinal float)
begin
	if (data is not null) then
		if(horaAbertura is not null) then
			if(saldoInicial is not null) then
				insert into Caixa values(null, data, horaAbertura, horaFechamento, saldoInicial, saldoFinal);
				select 'Caixa inserida com sucesso!' as Confirmacao;
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

drop procedure AtualizarCaixa;
select * from caixa;

call InserirCaixa("2022-11-10", "17:00:00", "18:00:00", 10000, 20000);


DELIMITER $$
create procedure AtualizarCaixa(codigo int, data date, horaAbertura time, horaFechamento time, saldoInicial float, saldoFinal float)
begin
	if (data is not null) then
		if(horaAbertura is not null) then
			if(saldoInicial is not null) then
				update Caixa set
				data_cai = data, 
				hora_abertura_cai = horaAbertura, 
				hora_fechamento_cai = horaFechamento, 
				saldo_inicial_cai = saldoInicial, 
				saldo_final_cai = saldoFinal
    
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

call AtualizarCaixa(1, "2020-12-21", "17:00:00", "18:00:00", 10000, 20000);


DELIMITER $$
create procedure InserirRecebimento(
	data date, 
    valor float, 
    hora time, 
    formaRecebimento varchar(300), 
    status varchar(100),
    caixaFK int, 
    vendaFK int)
begin
	if(data is not null) then
		if(caixaFK is not null) then
			if(vendaFK is not null) then
				insert into Recebimento values(null, data, valor, hora, formaRecebimento, status, caixaFK, vendaFK);
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

call inserirRecebimento("2022-12-01", 239, "12:00", "cartão", "aberto", 1, 1);

DELIMITER $$
create procedure AtualizarRecebimento(
	codigo int,
	data date, 
    valor float, 
    hora time, 
    formaRecebimento varchar(300), 
    status varchar(100),
    caixaFK int, 
    vendaFK int)
begin

	if(data is not null) then
		if(caixaFK is not null) then
			if(vendaFK is not null) then
				update Recebimento set 
				data_receb = data, 
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

call atualizarRecebimento(1, "2022-12-01", 239, "12:00", "cartão", "aberto", 1, 1);


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
call inserirPagamento("2022-10-11", 2000, "12:00", "Cartão", "fechado", 1, 1); 

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

call atualizarPagamento(1, "2022-10-11", 2000, "12:00", "Cartão", "fechado", 1, 1); 


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