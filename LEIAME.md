## Introdução ##

Esta biblioteca **.NET** visa facilitar a integração com a API da **maxiPago! Smart Payments**. Nossa plataforma permite aos lojistas virtuais aceitarem pagamentos em diversos países da América Latina e nos EUA e inclui funcionalidades como Cobrança Recorrente Automática, Pagamentos com 1-Clique, Estornos Online, Conciliação de Cartões de Crédito e Ferramentas Anti-Fraude. Se quiser saber mais sobre a **maxiPago!** visite [www.maxipago.com](http://www.maxipago.com/).

Esta biblioteca traz todas as funcionalidades atualmente disponívels na plataforma e ela pode ser copiada e usada livremente por Lojas e desenvolvedores.

Para ter uma visão mais aprofundada da nossa API baixe nossa documentação, [disponível aqui](http://www.maxipago.com/docs/maxiPago_API_Ultima.pdf). Se você está procurando por uma solução de página hospedada (*"hosted payment page"*), por favor veja a seção "**smartPages!**".


## Configuração ##

Configurar a biblioteca é bem simples: basta baixar o arquivo [maxiPago.dll](http://www.maxipago.com/docs/maxiPago.dll.zip), copiá-lo para seu servidor e importá-lo.

Para importação use o código a seguir:

		using MaxiPago.DataContract;
		using MaxiPago.Gateway;


## Ambiente e Credenciais ##

Para poder enviar requisições você precisará de Credenciais váliadas. Você pode consegui-las com nosso Suporte no endereço suporte [@] maxipago [.] com.

A **maxiPago!** oferece um ambiente de teste (*"sandbox"*) totalmente funcional para simular as transações. Você precisa definir o ambiente para que a biblioteca saiba para onde enviar as transações.

Para definier o ambiente use este código:

		transaction.Environment = "TEST";
		transaction.Environment = "LIVE";

Você também precisa informar as suas Credenciais colocando as variáveis **merchantId** e **merchantKey** em cada requisição


## Tipos de transação ##

* **Autorização:** verifica se o cartão de crédito usado é válido (número, CVV e data de validade) e se o comprador possui limite suficiente para a compra.

* **Captura:** confirma a autorização feita para aquele pedido e completa a transação. Se a transação nunca for capturada o Estabelecimento não receberá o dinheiro e o comprador não será cobrado.

>*Separar a autorização e a captura em dois momentos diferentes é uma ótima maneira de checar se você tem os produtos em estoque ou fazer uma análise de fraude, e ainda assim garantir o pagamento.*

* **Venda Direta:** combina a autorização e a captura em uma mesma chamada. Ao usar a requisição de Venda Direta você estará fazendo uma autorização no cartão do cliente e imediatamente capturando o valor total.

* **Void:**: cancela uma captura antes do fechamento do lote final do dia. Aqui o dinheiro não troca de mãos. Você só pode cancelar a venda até às 23h59 do dia da captura.

* **Estorno:** reverte uma transação de cartão de crédito, debitando o valor do Estabelecimento e devolvendo-o ao comprador. O estorno é uma operação financeira e, por esta razão, pode demorar alguns dias para serem aprovados por algumas processadoras.

* **Recorrente:** agenda uma transação de cartão de crédito para ser cobrada em um intervalo específico, definido pelo lojista.

* **Armazenar Cartão:** guarda um cartão em nosso sistema e devolve um token único, que pode ser usado em novas transações. **Isto permite a implantação de pagamentos com 1-clique no seu site.**

* **Boleto:** Transações feitas com Boleto funcionam de forma diferente das transações com cartão de crédito. Aqui geramos um boleto e retornamos uma URL para comprador que dá acesso ao boleto. Ela pode ser acessada a qualquer momento antes do vencimento do boleto e até 60 dias após o vencimento.


## Métodos disponíveis ##

Esta é uma lista completa dos comandos que podem ser executados com esta biblioteca.

* **Transações de Cartão de Crédito**
 * Autorização 
 * Captura 
 * Venda Direta (Autorização + Capura) 
 * Autorização com Token (cartão salvo)
 * Venda Direta com Token (cartão salvo) 
 * Cancelamento (*Void*)
 * Estorno 
 
* **Transações Recorrentes**
 * Criar nova recorrência
 
* **Transações de Boleto**
 * Criar boleto
 
* **Relatórios**
 * Sondar uma transação
 * Sondar uma lista de transações
 * Paginar a lista de transações 
 * Sondar um relatório pendente
 
* **Cadastro de Cliente / Salvar Cartão**
 * Criar um perfil  *(um perfil de cliente precisa ser criado antes de se salvar um cartão)*
 * Atualizar um perfil 
 * Remover um perfil 
 * Adicionar um cartão de crédito
 * Remover um cartão de crédito


## Requisições ##

Você achará exemplos de cada uma das requisições neste repositório. Se você tiver alguma dúvida sobre o envio ou resposta da transação, [por favor consulte nossa documentação](http://www.maxipago.com/docs/maxiPago_API_Ultima.pdf). Você também pode entrar em contato com nosso suporte, se preferir.


## Documentação e Suporte ##

[A documentação completa da API da **maxiPago!** pode ser encontrada aqui](http://www.maxipago.com/docs/maxiPago_API_Ultima.pdf).

Nossa equipe de suporte está à disposição para ajudá-lo com quaisquer assunto, seja sobre funcionalidades de nossa plataforma ou sobre pagamentos em geral. Eles estão disponíveis para clientes e não-clientes no endereço suporte [@] maxipago [.] com.

## Licença ##

Biblioteca de integração para o **Gateway de Pagamento maxiPago!**     
**_Copyright (C) 2013, maxiPago!_**

Este programa é um software livre; você pode redistribui-lo e/ou modifica-lo dentro dos termos da Licença Pública Geral GNU como publicada pela Fundação do Software Livre (FSF); na versão 2 da Licença, ou (na sua opnião) qualquer versão.

Este programa é distribuido na esperança que possa ser  util, mas SEM NENHUMA GARANTIA; sem uma garantia implicita de ADEQUAÇÂO a qualquer MERCADO ou APLICAÇÃO EM PARTICULAR. Veja a Licença Pública Geral GNU para maiores detalhes.

Você deve ter recebido uma cópia da Licença Pública Geral GNU junto com este programa, se não, escreva para a Fundação do Software Livre(FSF) Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301 - USA.