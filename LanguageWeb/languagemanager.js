languages =
{
    en: "language/en.json",
    pt: "language/pt.json"
};

function getLanguageUrl(langUrl) {
    var url = window.location.host;
    url = url + langUrl;
    return url;
}