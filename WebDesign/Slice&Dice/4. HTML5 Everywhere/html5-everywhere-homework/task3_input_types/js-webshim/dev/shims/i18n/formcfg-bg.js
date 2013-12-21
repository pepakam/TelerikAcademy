jQuery.webshims.validityMessages.bg = {
    "typeMismatch": {
        "defaultMessage": "{%value} ist in diesem Feld nicht zulässig.",
        "email": "{%value} ist keine zulässige E-Mail-Adresse",
        "url": "{%value} ist keine zulässige Webadresse",
        "number": "{%value} ist keine Nummer!",
        "date": "{%value} ist kein Datum",
        "time": "{%value} ist keine Uhrzeit",
        "month": "{%value} ist in diesem Feld nicht zulässig.",
        "range": "{%value} ist keine Nummer!",
        "datetime-local": "{%value} ist kein Datum-Uhrzeit Format."
    },
    "rangeUnderflow": {
        "defaultMessage": "{%value} ist zu niedrig. {%min} ist der unterste Wert, den Sie benutzen können.",
        "date": "{%value} ist zu früh. {%min} ist die früheste Zeit, die Sie benutzen können.",
        "time": "{%value} ist zu früh. {%min} ist die früheste Zeit, die Sie benutzen können.",
        "datetime-local": "{%value} ist zu früh. {%min} ist die früheste Zeit, die Sie benutzen können.",
        "month": "{%value} ist zu früh. {%min} ist die früheste Zeit, die Sie benutzen können."
    },
    "rangeOverflow": {
        "defaultMessage": "{%value} ist zu hoch. {%max} ist der oberste Wert, den Sie benutzen können.",
        "date": "{%value} ist zu spät. {%max} ist die späteste Zeit, die Sie benutzen können.",
        "time": "{%value} ist zu spät. {%max} ist die späteste Zeit, die Sie benutzen können.",
        "datetime-local": "{%value} ist zu spät. {%max} ist die späteste Zeit, die Sie benutzen können.",
        "month": "{%value} ist zu spät. {%max} ist die späteste Zeit, die Sie benutzen können."
    },
    "stepMismatch": "Der Wert {%value} ist in diesem Feld nicht zulässig. Hier sind nur bestimmte Werte zulässig. {%title}",
    "tooLong": "Der eingegebene Text ist zu lang! Sie haben {%valueLen} Zeichen eingegeben, dabei sind {%maxlength} das Maximum.",
    "patternMismatch": "{%value} hat für dieses Eingabefeld ein falsches Format! {%title}",
    "valueMissing": {
        "defaultMessage": "Bitte geben Sie einen Wert ein",
        "checkbox": "Bitte aktivieren Sie das Kästchen",
        "select": "Bitte wählen Sie eine Option aus",
        "radio": "Bitte wählen Sie eine Option aus"
    }
};
jQuery.webshims.formcfg.bg = {
	numberFormat: {
		",": ".",
		".": ","
	},
	timeSigns: ":. ",
	numberSigns: ',',
	dateSigns: '.',
	dFormat: ".",
	patterns: {
		d: "dd.mm.yy"
	},
	month:  {
		currentText: 'Aktueller Monat'
	},
	date: {
		close: 'schließen',
		clear: 'Löschen',
		prevText: 'zurück',
		nextText: 'Vor',
		currentText: 'Heute',
		monthNames: ['Januar','Februar','März','April','Mai','Juni',
		'Juli','August','September','Oktober','November','Dezember'],
		monthNamesShort: ['Jan','Feb','Mär','Apr','Mai','Jun',
		'Jul','Aug','Sep','Okt','Nov','Dez'],
		dayNames: ['Sonntag','Montag','Dienstag','Mittwoch','Donnerstag','Freitag','Samstag'],
		dayNamesShort: ['So','Mo','Di','Mi','Do','Fr','Sa'],
		dayNamesMin: ['So','Mo','Di','Mi','Do','Fr','Sa'],
		weekHeader: 'KW',
		firstDay: 1,
		isRTL: false,
		showMonthAfterYear: false,
		yearSuffix: ''
	}
};