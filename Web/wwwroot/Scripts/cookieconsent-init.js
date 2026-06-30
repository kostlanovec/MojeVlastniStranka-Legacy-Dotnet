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
                    text: 'Přijmout vše',
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
                accept_all_btn: 'Přijmout vše',
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
                        title: 'Používání souborů cookies 📢',
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
                                col2: 'www.kostlanovec.cz',
                                col3: '6 měsíců',
                                col4: 'Cookie, který si pamatuje předvolby cookies.',
                                is_regex: true
                            }]
                    }, {
                        title: 'Výkonnostní a analytické cookies',
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
                        description: 'Pro více informací se mrkněte na <a class="cc-link" href="/cs/gdpr">GDPR</a> a <a class="cc-link" href="/cs/zasadycookies">Zásady Cookies</a>.',
                    }
                ]
            }
        },
        'en': {
            consent_modal: {
                title: 'Privacy Settings',
                description: 'Hello, we use cookies on our website to improve your experience. <button type="button" data-cc="c-settings" class="cc-link">My preferences</button>',
                primary_btn: {
                    text: 'Accept all',
                    role: 'accept_all'
                },
                secondary_btn: {
                    text: 'Reject',
                    role: 'accept_necessary'
                }
            },
            settings_modal: {
                title: 'Cookie preferences',
                save_settings_btn: 'Save settings',
                accept_all_btn: 'Accept all',
                reject_all_btn: 'Reject all',
                close_btn_label: 'Close',
                cookie_table_headers: [
                    {col1: 'Name'},
                    {col2: 'Domain'},
                    {col3: 'Expiration'},
                    {col4: 'Description'}
                ],
                blocks: [
                    {
                        title: 'Cookie usage 📢',
                        description: 'I use cookies to ensure the basic functions of the website and to improve your online experience. For each category, you can choose to opt-in or opt-out whenever you want.'
                    }, {
                        title: 'Essential cookies',
                        description: 'These are necessary cookies for the proper functioning of my website. Without these cookies, the website could not function properly.',
                        toggle: {
                            value: 'necessary',
                            enabled: true,
                            readonly: true
                        },
                        cookie_table: [
                            {
                                col1: '^cc_cookie',
                                col2: 'www.kostlanovec.cz',
                                col3: '6 months',
                                col4: 'Cookie that remembers your cookie consent preferences.',
                                is_regex: true
                            }]
                    }, {
                        title: 'Performance and analytical cookies',
                        description: 'These cookies allow the website to remember choices you made in the past.',
                        toggle: {
                            value: 'analytics',
                            enabled: false,
                            readonly: false
                        },
                        cookie_table: [
                            {
                                col1: '^_ga',
                                col2: 'google.com',
                                col3: '2 years',
                                col4: 'This cookie is used to distinguish unique visitors on the site. It contains a randomly generated ID assigned to new users on each visit.',
                                is_regex: true
                            },
                            {
                                col1: '^_gid',
                                col2: 'google.com',
                                col3: '2 years',
                                col4: 'This cookie is used to identify a specific user visit to the page. It also contains a randomly generated ID assigned to new users on each visit.',
                            }
                        ]
                    }, {
                        title: 'Advertising and targeting cookies',
                        description: 'These cookies collect information about how you use the website, which pages you visited, and which links you clicked. All data is anonymized and cannot be used to identify you.',
                        toggle: {
                            value: 'targeting',
                            enabled: false,
                            readonly: false
                        }
                    }, {
                        title: 'More information',
                        description: 'For more information, take a look at <a class="cc-link" href="/en/gdpr">GDPR</a> and <a class="cc-link" href="/en/zasadycookies">Cookie Policy</a>.',
                    }
                ]
            }
        }
    }
});