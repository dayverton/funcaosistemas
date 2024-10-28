$(document).ready(function () {

    alternarBotaoModal();

    function alternarBotaoModal() {
        $('#btnModalBeneficiarios').prop('disabled', !localStorage.getItem('idCliente'));
    }

    function carregarBeneficiarios() {
        let idCliente = localStorage.getItem("idCliente");

        if (idCliente == null)
            return;

        $.ajax({
            url: '/Beneficiario/Listar',
            method: 'POST',
            data: { IdCliente: idCliente },

            error:
                function (r) {
                    if (r.status == 400)
                        ModalDialog("Ocorreu um erro", r.responseJSON);
                    else if (r.status == 500)
                        ModalDialog("Ocorreu um erro", "Ocorreu um erro interno no servidor.");
                },
            success:
                function (response) {
                    var tbody = $("#beneficiarioTableBody");
                    tbody.empty();

                    response.Records.forEach(function (beneficiario) {
                        var row = `<tr>
                        <td style="display: none;">${beneficiario.Id}</td>
                        <td style="width: 45%">${beneficiario.Nome}</td>
                        <td style="width: 25%">${beneficiario.CPF.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, '$1.$2.$3-$4')}</td>
                        <td>
                            <button class="btn btn-sm btn-warning btnAlterar" data-id="${beneficiario.Id}">Alterar</button>
                            <button class="btn btn-sm btn-danger btnExcluir" data-id="${beneficiario.Id}">Excluir</button>
                        </td>
                    </tr>`;
                        tbody.append(row);
                    });
                }
        });
    }

    $('#btnModalBeneficiarios').click(function (e) {
        e.preventDefault();

        $("#formBeneficiario")[0].reset();
        carregarBeneficiarios()

    });

    $('#btnIncluirBeneficiario').click(function (e) {
        e.preventDefault();

        let idCliente = localStorage.getItem("idCliente");

        $.ajax({
            url: '/Beneficiario/Incluir',
            method: "POST",
            data: {
                "NOME": $('#formBeneficiario').find("#nome").val(),
                "CPF": $('#formBeneficiario').find("#beneficiarioCPF").val(),
                "IDCLIENTE": idCliente
            },
            error:
                function (r) {
                    if (r.status == 400)
                        ModalDialog("Ocorreu um erro", r.responseJSON);
                    else if (r.status == 500)
                        ModalDialog("Ocorreu um erro", "Ocorreu um erro interno no servidor.");
                },
            success:
                function (r) {
                    ModalDialog("Sucesso!", r)
                    $("#formBeneficiario")[0].reset();
                    carregarBeneficiarios();
                }
        });
    });

    $(document).on('click', '.btnExcluir', function () {

        var id = $(this).data("id");
        $.ajax({
            url: '/Beneficiario/Excluir',
            method: 'POST',
            data: { Id: id },
            error:
                function (r) {

                    if (r.status == 400)
                        ModalDialog("Ocorreu um erro", r.responseJSON);
                    else if (r.status == 500)
                        ModalDialog("Ocorreu um erro", "Ocorreu um erro interno no servidor.");
                },
            success:
                function (r) {
                    ModalDialog("Sucesso!", r);
                    carregarBeneficiarios();
                }
        });
    });

    $(document).on('click', '.btnAlterar', function () {
        var row = $(this).closest('tr');
        $('#beneficiarioId').val(row.find('td:eq(0)').text());
        $('#nome').val(row.find('td:eq(1)').text());
        $('#beneficiarioCPF').val(row.find('td:eq(2)').text());
        $('#btnIncluirBeneficiario').hide();
        $('#btnAlterarBeneficiario').show();
    });

    $('#btnAlterarBeneficiario').click(function () {
        var id = $('#beneficiarioId').val();
        let idCliente = localStorage.getItem("idCliente");

        $.ajax({
            url: '/Beneficiario/Alterar',
            method: 'POST',
            data: {
                Id: id,
                Nome: $('#nome').val(),
                CPF: $('#beneficiarioCPF').val(),
                IdCliente: idCliente
            },
            error:
                function (r) {
                    if (r.status == 400)
                        ModalDialog("Ocorreu um erro", r.responseJSON);
                    else if (r.status == 500)
                        ModalDialog("Ocorreu um erro", "Ocorreu um erro interno no servidor.");
                },
            success:
                function (r) {
                    ModalDialog("Sucesso!", r);
                    $("#formBeneficiario")[0].reset();
                    $('#btnAlterarBeneficiario').hide();
                    $('#btnIncluirBeneficiario').show();
                    carregarBeneficiarios();
                }
        });
    });

});
