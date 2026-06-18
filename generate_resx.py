import xml.etree.ElementTree as ET
from xml.dom import minidom
import os

def create_resx(data, filepath):
    root = ET.Element("root")
    headers = [
        ("resmimetype", "text/microsoft-resx"),
        ("version", "2.0"),
        ("reader", "System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"),
        ("writer", "System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")
    ]
    for name, value in headers:
        header = ET.SubElement(root, "resheader", name=name)
        val = ET.SubElement(header, "value")
        val.text = value
        
    for k, v in data.items():
        data_elem = ET.SubElement(root, "data", name=k)
        data_elem.set("xml:space", "preserve")
        val_elem = ET.SubElement(data_elem, "value")
        val_elem.text = v

    xmlstr = minidom.parseString(ET.tostring(root)).toprettyxml(indent="  ")
    with open(filepath, "w", encoding="utf-8") as f:
        f.write(xmlstr)

cs_data = {
    "Kostlanovec": "Kostlanovec",
    "Blog": "Blog",
    "Projekty": "Projekty",
    "Kontakt": "Kontakt",
    "MadeBy": "Made by Jan Sebastián Kostlán",
    "GDPR": "GDPR",
    "Cookies": "Cookies",
    "SubTitle": "Webdeveloper, programátor, webdesigner a SEO specialista. Tvořím rychlé a přístupné weby, hry a aplikace.",
    "Services": "Služby",
    "WebDevelopment": "Webové stránky",
    "GameDevelopment": "Tvorba her",
    "SocialMedia": "Správa sociálních sítí",
    "SEO": "Optimalizace SEO",
    "AboutMeTitle": "O mně",
    "AboutMeP1": "Jmenuji se <strong>Jan Sebastián Kostlán</strong> a věnuji se hlavně <em>vývoji webů, programování, webdesignu a SEO</em>. Baví mě hledat spojení mezi technickým řešením a reálnými výsledky. Tvořím <strong>rychlé, přístupné a bezpečné webové stránky</strong>, vyvíjím <strong>hry a aplikace</strong> a k tomu řeším <strong>online marketing</strong>, aby projekty nebyly jen hezké, ale i dobře viditelné a efektivní.",
    "AboutMeP2": "V praxi pracuji s .NET/ASP.NET Core a moderními frontend technologiemi, rád automatizuji nasazování přes Docker a CI/CD a hlídám kvalitu – od Core Web Vitals po přístupnost. Díky zkušenostem s <strong>SEO</strong> a analýzou dat umím navrhnout obsah i strukturu webu tak, aby měl co nejlepší výkon ve vyhledávačích.",
    "AboutMeP3": "Mám také specifické okruhy zájmů, kterým se aktivně věnuji. Patří mezi ně především <strong>vývoj her v Unity</strong> – od menších prototypů až po multiplayer projekty. Zajímá mě čistá architektura, dobrý uživatelský zážitek a to, aby každá aplikace nebo hra měla měřitelný přínos.",
    "AboutMeP4": "Ve volném čase se věnuji hlavně <strong>fitness a silovému tréninku</strong>, který mi pomáhá vyvážit práci u počítače a zároveň mě motivuje posouvat vlastní hranice. Stejně jako v IT, i ve sportu mě baví sledovat svůj postup a hledat způsoby, jak být každý den o krok dál.",
    "AboutMeP5": "Mým cílem je <strong>zanechat stopu v každém z okruhů, které mě baví</strong> – od <em>webů a aplikací</em>, přes <em>hry a SEO</em>, až po <em>osobní rozvoj</em>. Chci tvořit věci, které mají hodnotu a dlouhodobý smysl, a ukazovat, že kombinace techniky, kreativity a vytrvalosti dokáže posunout hranice.",
    "AboutMeP6": "Chceš vidět, na čem zrovna pracuji? Podívej se na moje <a href=\"/projekty\">projekty</a> nebo si přečti <a href=\"/blog\">blog</a>. Pokud máš zájem o spolupráci na webu, hře nebo o konzultaci k SEO, ozvi se mi přes <a href=\"/kontakt\">kontakt</a>. Rád proberu tvůj nápad a navrhnu řešení.",
    "NewsletterTitle": "Buď v obraze",
    "NewsletterDesc": "Přihlas se k odběru novinek o nových projektech, článcích a užitečných tipech. Stačí e-mail níže.",
    "Submit": "Odeslat",
    "EmailPlaceholder": "E-mail",
    "IndexTitle": "Webdeveloper, programátor & SEO specialista",
    "IndexDesc": "Tvořím rychlé webové stránky, aplikace a SEO řešení. Webdeveloper a SEO specialista zaměřený na výkon, použitelnost a výsledky.",
    "IndexKeywords": "Jan Sebastián Kostlán, webdeveloper, SEO specialista, tvorba webových stránek, optimalizace webu, výkonné weby",
    "IndexSocialTitle": "Jan Sebastián Kostlán – webdeveloper & SEO"
}

en_data = {
    "Kostlanovec": "Kostlanovec",
    "Blog": "Blog",
    "Projekty": "Projects",
    "Kontakt": "Contact",
    "MadeBy": "Made by Jan Sebastián Kostlán",
    "GDPR": "GDPR",
    "Cookies": "Cookies",
    "SubTitle": "Web developer, programmer, web designer, and SEO specialist. I create fast, accessible websites, games, and apps.",
    "Services": "Services",
    "WebDevelopment": "Web Development",
    "GameDevelopment": "Game Development",
    "SocialMedia": "Social Media Management",
    "SEO": "SEO Optimization",
    "AboutMeTitle": "About Me",
    "AboutMeP1": "My name is <strong>Jan Sebastián Kostlán</strong>, and I focus primarily on <em>web development, programming, web design, and SEO</em>. I enjoy finding the connection between technical solutions and real-world results. I create <strong>fast, accessible, and secure websites</strong>, develop <strong>games and apps</strong>, and manage <strong>online marketing</strong> to ensure projects aren't just good-looking, but also visible and effective.",
    "AboutMeP2": "In practice, I work with .NET/ASP.NET Core and modern frontend technologies. I enjoy automating deployments using Docker and CI/CD, and ensuring quality—from Core Web Vitals to accessibility. Thanks to my experience with <strong>SEO</strong> and data analysis, I can design website content and structure for the best search engine performance.",
    "AboutMeP3": "I also have specific areas of interest that I actively pursue. Chief among these is <strong>game development in Unity</strong>—from small prototypes to multiplayer projects. I care about clean architecture, great user experience, and ensuring that every app or game has measurable value.",
    "AboutMeP4": "In my free time, I focus on <strong>fitness and strength training</strong>, which helps me balance computer work and motivates me to push my boundaries. Just like in IT, I enjoy tracking my progress in sports and finding ways to be one step further every day.",
    "AboutMeP5": "My goal is to <strong>leave a mark in every field I enjoy</strong>—from <em>websites and apps</em>, to <em>games and SEO</em>, to <em>personal growth</em>. I want to build things that hold long-term value and prove that the combination of technology, creativity, and perseverance can push boundaries.",
    "AboutMeP6": "Want to see what I'm working on right now? Check out my <a href=\"/projekty\">projects</a> or read my <a href=\"/blog\">blog</a>. If you're interested in collaborating on a website, game, or need SEO consultation, reach out via <a href=\"/kontakt\">contact</a>. I'd love to discuss your idea and propose a solution.",
    "NewsletterTitle": "Stay Updated",
    "NewsletterDesc": "Subscribe to get news about new projects, articles, and useful tips. Just enter your email below.",
    "Submit": "Submit",
    "EmailPlaceholder": "Email",
    "IndexTitle": "Web Developer, Programmer & SEO Specialist",
    "IndexDesc": "I create fast websites, applications, and SEO solutions. Web developer and SEO specialist focused on performance, usability, and results.",
    "IndexKeywords": "Jan Sebastián Kostlán, web developer, SEO specialist, website creation, web optimization, high-performance websites",
    "IndexSocialTitle": "Jan Sebastián Kostlán – Web Developer & SEO"
}

os.makedirs("/home/user/MojeVlastniStrankaFinanali/Web/Resources", exist_ok=True)
create_resx(cs_data, "/home/user/MojeVlastniStrankaFinanali/Web/Resources/SharedResource.cs.resx")
create_resx(en_data, "/home/user/MojeVlastniStrankaFinanali/Web/Resources/SharedResource.en.resx")
create_resx(cs_data, "/home/user/MojeVlastniStrankaFinanali/Web/Resources/SharedResource.resx")
