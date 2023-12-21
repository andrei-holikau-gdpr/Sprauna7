function startmap_1(message) {
    //const script = document.createElement('script');
    //script.src = 'https://api-maps.yandex.ru/3.0/?apikey=d44f3203-a59c-4af9-9caf-441f6a92eb95&lang=ru_RU';
    //document.head.appendChild(script);
}

async function startmap_v3(message) {
    // Промис `ymaps3.ready` будет зарезолвлен, когда загрузятся все компоненты API
    await ymaps3.ready;

    // Создание карты
    var map = new ymaps3.YMap(document.getElementById('YMapsID'), {
        location: {
            // Координаты центра карты
            // Порядок по умолчанию: «долгота, широта»
            center: [55.205247, 25.077816],

            // Уровень масштабирования
            // Допустимые значения: от 0 (весь мир) до 21.
            zoom: 10
        }
    });

    // Добавляем слой для отображения схематической карты
    map.addChild(new ymaps3.YMapDefaultSchemeLayer());
}

async function startmap_v2(message) {

    // Функция ymaps.ready() будет вызвана, когда
    // загрузятся все компоненты API, а также когда будет готово DOM-дерево.

    ymaps.ready(init);

    function init() {
        // Создание карты.
        myMap = new ymaps.Map("YMapsID", {
            // Координаты центра карты.
            // Порядок по умолчанию: «широта, долгота».
            // Чтобы не определять координаты центра карты вручную,
            // воспользуйтесь инструментом Определение координат. http://dimik.github.io/ymaps/examples/location-tool/
            center: [53.90123196, 27.56053627],
            // Уровень масштабирования. Допустимые значения:
            // от 0 (весь мир) до 19.
            zoom: 7,
            controls: []
        });

        // Создадим экземпляр элемента управления «поиск по карте»
        // с установленной опцией провайдера данных для поиска по организациям.
        var searchControl = new ymaps.control.SearchControl({
            options: {
                provider: 'yandex#search'
            }
        });

        myMap.controls.add(searchControl);
        // Программно выполним поиск определённых кафе в текущей
        // прямоугольной области карты.
        searchControl.search(message);
    }

}

async function startmap_search(message) {

    var element = document.getElementById("YMapsID");
    while (element.firstChild) {
        element.removeChild(element.firstChild);
    }
    startmap_v2(message);
}