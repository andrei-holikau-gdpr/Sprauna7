window.setMask = () => {
    var phoneMask = IMask(
        document.getElementById('ContactNumber'), {
        mask: '+000 (00) 000-00-00'
    });
};

window.onClickloadAllProductSp = () => {
    document.getElementById("loadAllProductSp").click();
};

window.showModalUnit = () => {
    document.getElementById("modDialog").modal('show');
};

window.ModalBtnCloseOnClick = () => {
    console.log("window.ModalBtnCloseOnClick");
    document.querySelector("#PackagesModal .btn-close").click();
}

window.InitialiseTable = () => {


    var spDataTable = $('#example');
    if (spDataTable !== undefined) {
        spDataTable.DataTable({
            language: {
                lengthMenu: 'Показать _MENU_ записей на странице',
                zeroRecords: 'Ничего не найдено - извините',
                info: 'Показана страница _PAGE_ из _PAGES_<br/>',
                infoEmpty: 'Нет доступных записей',
                infoFiltered: '(отфильтровано из _MAX_ записей)',
                search: 'Поиск: ',
                paginate: {
                    "first": "Первая",
                    "last": "Последняя",
                    "next": "Следующая",
                    "previous": "Предыдущая"
                },

            },
            dom: 'Bfrtip',
            buttons: [
                {
                    extend: 'colvis',
                    text: 'Колонки'
                },
                /*'colvis', 'copy', 'csv', 'excel', 'pdf', 'print'*/
            ],
            keys: true,
            scrollY: 300,
            select: {
                items: 'row'
            },
            colReorder: true,

        });
    } 

    //new $.fn.dataTable.Responsive(table, {
    //    details: $.fn.dataTable.Responsive.display.childRowImmediate
    //});
}


window.DataTablesRemove = () => {    
    $('#example').DataTable().destroy();
    // Removes the datatable wrapper from the dom.
    var elem = document.querySelector(table + '_wrapper');
    elem.parentNode.removeChild(elem);
}


/*$(document).ready(function () {*/
/*    });*/


//// Setup - add a text input to each footer cell
//$('#example tfoot th').each(function () {
//    var title = $(this).text();
//    $(this).html('<input type="text" placeholder="Поиск ' + title + '" />');
//});
//initComplete: function () {
//    // Apply the search
//    this.api()
//        .columns()
//        .every(function () {
//            var that = this;

//            $('input', this.footer()).on('keyup change clear', function () {
//                if (that.search() !== this.value) {
//                    that.search(this.value).draw();
//                }
//            });
//        });
//},