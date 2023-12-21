window.AddIonRangeSlider = () => {
    console.log("AddIonRangeSlider");

    if (window.location.pathname === "/cost-delivery") {
        const script = document.createElement('script');
        script.src = 'https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js';
        document.body.appendChild(script);
    }
    if (window.location.pathname === "/cost-delivery") {
        const script = document.createElement('script');
        script.src = 'https://cdnjs.cloudflare.com/ajax/libs/ion-rangeslider/2.3.1/js/ion.rangeSlider.min.js';
        document.body.appendChild(script);
    }
    if (window.location.pathname === "/cost-delivery") {
        const link = document.createElement('link');
        link.rel = 'stylesheet';
        link.href = 'https://cdnjs.cloudflare.com/ajax/libs/ion-rangeslider/2.3.1/css/ion.rangeSlider.min.css';
        document.head.appendChild(link);
    }
}

// http://ionden.com/a/plugins/ion.rangeslider/index.html
window.CostOfDelivery = () => {
    console.log("CostOfDelivery");

    //$(".js-range-slider-1").ionRangeSlider({
    //    skin: "round"
    //});

    $(".js-range-slider-1").ionRangeSlider(jsRangeSliderData);

    document.querySelectorAll('.product-type img').forEach(
        function (item, index, array) {
            item.addEventListener('click', function () {

                var product_type_range_from = item.closest('.product-type').dataset.weight;
                console.log('shirt click');
                console.log('item.closest(.product-type): ');
                console.log(item.closest('.product-type'));

                // 1. Initialise range slider instance
                $(".js-range-slider-1").ionRangeSlider();

                // 2. Save instance to variable
                var my_range = $(".js-range-slider-1").data("ionRangeSlider");

                // 3. Update range slider content (this will change handles positions)
                my_range.update({
                    from: product_type_range_from
                });

                ChangeAndUpadateJsRangeSlider(my_range.data);
            });
        }
    );
}

function ChangeAndUpadateJsRangeSlider(data) {
    if (data != undefined) {
        // Called every time handle position is changed

        // console.log('onChange data.from: ' + data.from);

        // console.log('onChange data.from: ');
        console.log(data.from);

        document.querySelector('#sp-weight-1').textContent = data.from;

        var price = GetPrice(data.from);
        var pricePln = '';

        if (price == undefined) {
            pricePln = '';
        } else {
            pricePln = price.pln;
        }
        document.querySelector('#sp-price-1').textContent = pricePln;
    }
}

var jsRangeSliderData = {
    skin: "round",
    prettify: my_prettify,
    onStart: function (data) {
        // Called right after range slider instance initialised
        console.log('onStart');
        console.log('data.input: ');
        console.log(data.input);        // jQuery-link to input
        console.log('data.slider: ');
        console.log(data.slider);       // jQuery-link to range sliders container
        console.log('data.min: ' + data.min);          // MIN value
        console.log('data.max: ' + data.max);          // MAX values
        console.log('data.from: ' + data.from);         // FROM value
        console.log('data.from_percent: ' + data.from_percent); // FROM value in percent
        console.log('data.min_pretty: ' + data.min_pretty);   // MIN prettified (if used)
        console.log('data.max_pretty ' + data.max_pretty);   // MAX prettified (if used)
        console.log('data.from_pretty: ' + data.from_pretty);  // FROM prettified (if used)
    },

    onChange: function (data) {
        ChangeAndUpadateJsRangeSlider(data);
    },


    onUpdate: function (data) {
        ChangeAndUpadateJsRangeSlider(data);
    }
};

function my_prettify(weight) {
    var price = GetPrice(weight);

    if (price == undefined) {
        return weight;
    } else {
        return 'до ' + weight + "кг → " + price.pln + 'PLN';
    }
}

function GetPrice(weight) {

    var priceArray = [
        { weight: '0.5', pln: '44' },
        { weight: '1', pln: '63' },
        { weight: '2', pln: '76' },
        { weight: '3', pln: '84' },
        { weight: '4', pln: '114' },
        { weight: '5', pln: '136' },
        { weight: '6', pln: '158' },
        { weight: '7', pln: '181' },
        { weight: '8', pln: '203' },
        { weight: '9', pln: '226' },
        { weight: '10', pln: '248' },
        { weight: '11', pln: '270' },
        { weight: '12', pln: '293' },
        { weight: '13', pln: '315' },
        { weight: '14', pln: '338' },
        { weight: '15', pln: '360' },
        { weight: '16', pln: '382' },
        { weight: '17', pln: '405' },
        { weight: '18', pln: '427' },
        { weight: '19', pln: '450' },
        { weight: '20', pln: '472' },
        { weight: '21', pln: '494' },
        { weight: '22', pln: '517' },
        { weight: '23', pln: '539' },
        { weight: '24', pln: '562' },
        { weight: '25', pln: '584' },
        { weight: '26', pln: '606' },
        { weight: '27', pln: '629' },
        { weight: '28', pln: '651' },
        { weight: '29', pln: '674' },
        { weight: '30', pln: '696' }
    ];

    var price = priceArray.find(item => item.weight == weight);

    return price;
}