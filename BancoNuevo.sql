create database bd_loja_de_roupas;
use bd_loja_de_roupas;

create table Loja(
id_loja int primary key auto_increment,
nome_loja varchar(300), 
cnpj_loja varchar(300),
endereco varchar(300)
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
salario_func varchar(300),
status_func varchar(100),
id_loja_fk int,
foreign key (id_loja_fk) references Loja (id_loja)
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
logo_mar longblob,
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
foreign key (id_func_fk) references funcionario (id_func),
id_cli_fk int,
foreign key(id_cli_fk) references CLiente(id_cli)
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
id_mar_fk int,
foreign key (id_mar_fk) references Marca (id_mar)
);
##n/n venda && compra 

create table Compra(
id_com int primary key auto_increment,
data_com date,
hora_com time, 
valor_com float,
status_comp varchar(100),
id_forn_fk int,
foreign key (id_forn_fk) references Fornecedor (id_forn)
);


create table Despesa(
id_desp int primary key auto_increment,
descricao_desp varchar(300),
vencimento_desp date,
valor_desp float,
status_desp varchar(100),
id_com_fk int,
foreign key (id_com_fk) references Compra (id_com) 
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
foreign key (id_cai_fk) references Caixa (id_cai),
id_ven_fk int,
foreign key (id_ven_fk) references Venda (id_ven)
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
foreign key (id_cai_fk) references Caixa (id_cai),
id_desp_fk int,
foreign key (id_desp_fk) references Despesa (id_desp)
);



create table Venda_Roupa(
id_ven_roup int primary key auto_increment,
quantidade_ven_roup int,
id_ven_fk int,
foreign key (id_ven_fk) references venda (id_ven),
id_roup_fk int,
foreign key (id_roup_fk) references roupa (id_roup)
);


create table Compra_Roupa(
id_com_roup int primary key auto_increment,
quantidade_com_roup int
);
