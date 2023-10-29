from flask import Flask, request, jsonify
from textblob import TextBlob
from sklearn.feature_extraction.text import TfidfVectorizer
from sklearn.naive_bayes import MultinomialNB
import re

app = Flask(__name__)
api = Api(app)

# to-do čtení z databáze, takže je potřeba vytvoři ke kategorii seznam klíčových slov aby se vhodně rozpoznalo, co za kategorie to je, tohle je pro testovací účely vygenerované chatgpt
categories = {
    "Móda": "kravata oblečení móda styl šatník",
    "Technologie": "technologie počítač aplikace inovace",
    "Cestování": "cestování turistika dovolená místa průvodce",
    "Ostatní": "ostatní různé jiné"
}

# Seznam ignorovaných slov by se četlo z nějakého souboru, aby se s stím lépe pracovalo
ignored_words = ["je", "který", "pro", "a", "k", "může", "vám", "zde", "tu", "na", "i", "u", "se", "co", "v", "s", "které"]



@app.route('/')
def home ():
    return "Hello, World!"



@app.route('/process_article', methods=['POST'])
def process_article():
    try:
        data = request.get_json()
        article_text = data['article_text']

        vectorizer = TfidfVectorizer()
        X = vectorizer.fit_transform(categories.values())
        y = list(categories.keys())

        clf = MultinomialNB()
        clf.fit(X, y)

        blob = TextBlob(article_text)

        title = str(blob.sentences[0])

        slug = re.sub(r'\W+', '-', title.lower())

        description_sentences = [str(sentence) for sentence in blob.sentences[:2]]
        description = " ".join(description_sentences)

        keywords = [word for word in set(blob.words.lower()) if word not in ignored_words]

        predicted_category = clf.predict(vectorizer.transform([" ".join(keywords)]))[0]

        result = {
            "title": title,
            "slug": slug,
            "description": description,
            "keywords": keywords,
            "predicted_category": predicted_category
        }

        return jsonify(result), 200
    except KeyError as e:
        return jsonify({"error": "Key not found in request"}), 400
    except Exception as e:
        return jsonify({"error": str(e)}), 500


@app.route('/test', methods=['GET'])
def test():
    return jsonify({"message": "Server is up and running"}), 200

if __name__ == '__main__':
    app.run(host='localhost', port=5432, debug=True)