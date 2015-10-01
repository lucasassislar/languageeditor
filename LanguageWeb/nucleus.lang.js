var language = window.navigator.userLanguage || window.navigator.language;
var forcedLang = getUrlVars()['lang'];
if (forcedLang != null) {
    language = forcedLang;
}

language = language.toLowerCase();

var langPath = languages[language];
if (langPath == null) {
    var split = language.split('-');
    langPath = languages[split[0]];
    if (langPath == null) {
        for (var s in languages) {
            langPath = languages[s];
            break;
        }
    }
}

var client = new XMLHttpRequest();
client.open('GET', langPath);
client.onreadystatechange = function () {
    if (client.responseText == null || client.responseText == "") {
        return;
    }

    var langFile = JSON.parse(client.responseText);

    fixElement(document.getElementsByTagName("BODY")[0], langFile);
    fixElement(document.getElementsByTagName("TITLE")[0], langFile);
}
client.send();

function fixElement(body, langFile) {
    var html = body.outerHTML;
    var start = 0;
    var index = 0;

    for (; ;) {
        index = html.indexOf('$', start);
        if (index == -1) {
            break;
        }
        if (index > 0) {
            var bf = html[index - 1];
            if (bf == 'R') { // quich hack for no R$ crashing
                start = index + 1;
                continue;
            }
        }

        var endIndex = html.indexOf('$', index + 1);
        if (endIndex == -1) {
            break;
        }
        var word = html.substring(index + 1, endIndex);

        var langed = langFile.data[word];
        if (langed != null) {
            html = html.replace('$' + word + '$', langed);
        }
        else {
            html = html.replace('$' + word + '$', '');
        }
    }

    body.outerHTML = html;
}

function getUrlVars() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split('=');
        vars.push(hash[0]);
        vars[hash[0]] = hash[1];
    }
    return vars;
}