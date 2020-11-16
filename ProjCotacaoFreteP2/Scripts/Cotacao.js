function SalvarPedido() {
    //Nome
    var nome_cliente = $("#nome_cliente").val();
    var cpf_cnpj = $("#cpf_cnpj").val();
    var logradouro = $("#logradouro").val();
    var cidade = $("#cidade").val();
    var uf = $("#uf").val();
    var numero = $("#numero").val();
    var cep = $("#cep").val();
    var complemento = $("#complemento").val();
    var peso = $("#peso").val();
    var valor = $("#valor").val();
    var fkembalagem = $("#fkembalagem").val();
    var fkempresa = $("#fkempresa").val();
    //Deve ser inserido devido ao tratamento de segurança "URL":
    var token = $('input[name="__RequestVerificationToken"]').val();
    var tokenadr = $('form[action="/Pedido/Create"] input[name = "__RequestVerificationToken"]').val();
    var headers = {};
    var headersadr = {};
    headers['__RequestVerificationToken'] = token;
    headersadr['__RequestVerificationToken'] = tokenadr;
    //Gravar
    var url = "/pedidoes/Create";
    $.ajax({
        url: url
        , type: "POST"
        , datatype: "json"
        , headers: headersadr
        , data: { Id: 0, nome_cliente: nome_cliente, cpf_cnpj: cpf_cnpj, logradouro: logradouro, cidade: cidade, uf: uf, numero: numero, cep: cep, complemento: complemento, peso: peso, valor: valor, fkembalagem: fkembalagem, fkempresa: fkempresa, __RequestVerificationToken: token}
        , success: function (data) {
            if (data.Resultado > 0) {
                debugger;
                ListarItens(data.Resultado);
            }
        }
    });
}
function ListarItens(idPedido) {
    debugger;
    var url = "/Itens/ListarItens";
    $.ajax({
        url: url
        , type: "GET"
        , data: { id: idPedido }
        , datatype: "html"
        , success: function (data) {
            var divItens = $("#divItens");
            divItens.empty();
            divItens.show();
            divItens.html(data);
        }
    });
}
function SalvarCotacao() {
    debugger;
    var fktransportadora = $("#fktransportadora").val();
    var dias_entrega = $("#dias_entrega").val();
    var valor = $("#valor").val();
    var idPedido = $("#idPedido").val();

    var url = "/Itens/SalvarCotacao";
    $.ajax({
        url: url
        , data: { fktransportadora: fktransportadora, dias_entrega: dias_entrega, valor: valor, idPedido: idPedido }
        , type: "GET"
        , datatype: "html"
        , success: function (data) {
            if (data.Resultado > 0) {
                ListarItens(idPedido);
            }
        }
    });
}