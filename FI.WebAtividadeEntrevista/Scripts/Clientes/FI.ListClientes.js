
$(document).ready(function () {

    if (document.getElementById("gridClientes"))
        $('#gridClientes').jtable({
            title: 'Clientes',
            paging: true, //Enable paging
            pageSize: 5, //Set page size (default: 10)
            sorting: true, //Enable sorting
            defaultSorting: 'Nome ASC', //Set default sorting
            actions: {
                listAction: urlClienteList,
            },
            fields: {
                Nome: {
                    title: 'Nome',
                    width: '50%'
                },
                Email: {
                    title: 'Email',
                    width: '35%'
                },
                Alterar: {
                    title: '',
                    display: function (data) {
                        //return '<button onclick="window.location.href=\'' + urlAlteracao + '/' + data.record.Id + '\'" class="btn btn-primary btn-sm">Alterar</button>';
                        return '<button class="btnAlterar btn btn-primary btn-sm" data-id="' + data.record.Id + '">Alterar</button>';
                    }
                }
            }
        });

    $(document).on("click", ".btnAlterar", function () {
        var idCliente = $(this).data("id"); 
        localStorage.setItem("idCliente", idCliente);
        window.location.href = urlAlteracao + '/' + idCliente;
    });

    //Load student list from server
    if (document.getElementById("gridClientes"))
        $('#gridClientes').jtable('load');

    $('#novoClienteLink').on('click', function () {
        localStorage.removeItem('idCliente');
    });
})