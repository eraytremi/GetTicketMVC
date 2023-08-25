
    $('#search-date').datepicker({
        isRTL: false,
        format: 'dd.mm.yyyy',
        autoclose: true,
        language: 'tr'
    });
    $('#txtDeparturePoint,#txtDestinationPoint').select2({ width: '100%' });

    var today = new Date().toISOString().split('T')[0];

    document.getElementById('search-date').setAttribute('min', today);


















