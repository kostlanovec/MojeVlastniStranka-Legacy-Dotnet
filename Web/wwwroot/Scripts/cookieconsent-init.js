var cc = initCookieConsent();

// run plugin with your configuration
cc.run({
    current_lang: document.documentElement.getAttribute('lang'),
    autoclear_cookies: true,                   // default: false
    page_scripts: true,                        // default: false

    // mode: 'opt-in'                          // default: 'opt-in'; value: 'opt-in' or 'opt-out'
    // delay: 0,                               // default: 0
    // auto_language: null                     // default: null; could also be 'browser' or 'document'
    // autorun: true,                          // default: true
    // force_consent: false,                   // default: false
    hide_from_bots: true,                   // default: true
    // remove_cookie_tables: false             // default: false
    // cookie_name: 'cc_cookie',               // default: 'cc_cookie'
    // cookie_expiration: 182,                 // default: 182 (days)
    // cookie_necessary_only_expiration: 182   // default: disabled
    // cookie_domain: location.hostname,       // default: current domain
    // cookie_path: '/',                       // default: root
    // cookie_same_site: 'Lax',                // default: 'Lax'
    // use_rfc_cookie: false,                  // default: false
    // revision: 0,                            // default: 0

    onFirstAction: function(user_preferences, cookie){
        // callback triggered only once
    },

    onAccept: function (cookie) {
        // ...
    },

    onChange: function (cookie, changed_preferences) {
        // ...
    },

    languages: {
        'cs': {
            consent_modal: {
                title: 'Nastavení soukromí',
                description: 'Zdravím, na našich webových stránkách používáme soubory cookies pro zlepšení zážitku na naší stránce. <button type="button" data-cc="c-settings" class="cc-link">Moje preference</button>',
                primary_btn: {
                    text: 'Příjmout vše',
                    role: 'accept_all'              // 'accept_selected' or 'accept_all'
                },
                secondary_btn: {
                    text: 'Odmítnout',
                    role: 'accept_necessary'        // 'settings' or 'accept_necessary'
                }
            },
            settings_modal: {
                title: 'Cookies preference',
                save_settings_btn: 'Uložit nastavení',
                accept_all_btn: 'Příjmout vše',
                reject_all_btn: 'Odmítnout vše',
                close_btn_label: 'Zavřít',
                cookie_table_headers: [
                    {col1: 'Name'},
                    {col2: 'Domain'},
                    {col3: 'Expiration'},
                    {col4: 'Description'}
                ],
                blocks: [
                    {
                        title: 'Používání souboru cookies 📢',
                        description: 'Soubory cookie používám k zajištění základních funkcí webu a ke zlepšení vašeho online zážitku. Pro každou kategorii si můžete vybrat, zda se chcete přihlásit/odhlásit, kdykoli budete chtít.'
                    }, {
                        title: 'Nutné cookies',
                        description: 'Toto jsou nezbytné cookies pro správné fungování mé webové stránky. Bez těchto cookies by webová stránka nemohla správně fungovat.',
                        toggle: {
                            value: 'necessary',
                            enabled: true,
                            readonly: true          // cookie categories with readonly=true are all treated as "necessary cookies"
                        },
                        cookie_table: [             // list of all expected cookies
                            {
                                col1: '^cc_cookie',       // match all cookies starting with "_ga"
                                col2: 'www.kostlanovec.com',
                                col3: '6 měsíců',
                                col4: 'Cookie, který jsi pamatuje předvolby cookies.',
                                is_regex: true
                            }]
                    }, {
                        title: 'Výkonnostní a anylytické cookies',
                        description: 'Tyto cookies umožňují webové stránce pamatovat si volby, které jste v minulosti provedli.',
                        toggle: {
                            value: 'analytics',     // your cookie category
                            enabled: false,
                            readonly: false
                        },
                        cookie_table: [             // list of all expected cookies
                            {
                                col1: '^_ga',       // match all cookies starting with "_ga"
                                col2: 'google.com',
                                col3: '2 roky',
                                col4: 'cookie slouží k rozlišování jednotlivých návštěvníků na stránce. Tento soubor cookie obsahuje náhodně generované identifikační číslo, které je při každé návštěvě webové stránky přiděleno novému uživateli.',
                                is_regex: true
                            },
                            {
                                col1: '^_gid',
                                col2: 'google.com',
                                col3: '2 roky',
                                col4: 'cookie slouží k identifikaci konkrétní návštěvy uživatele na stránce. Tento soubor cookie obsahuje také náhodně generované identifikační číslo, které je při každé návštěvě stránky přiděleno novému uživateli.',
                            }
                        ]
                    }, {
                        title: 'Reklamní a cílené cookies',
                        description: 'Tyto cookies sbírají informace o tom, jak používáte webovou stránku, které stránky jste navštívili a na které odkazy jste klikli. Všechna data jsou anonymizována a nelze je použít k vašemu identifikování.',
                        toggle: {
                            value: 'targeting',
                            enabled: false,
                            readonly: false
                        }
                    }, {
                        title: 'Více informací',
                        description: 'Pro více informací se mrkněte na <a class="cc-link" href="/gdpr.html">GDPR</a> a <a class="cc-link" href="/zasadycookies.html">Zásady Cookies</a>.',
                    }
                ]
            }
        }

    }
});