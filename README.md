# BLOC2-AC03-ContinuousIntegration :floppy_disk:

# Membres del grup :busts_in_silhouette:
- Luca Bulla
- Maria Baos
- Hugo Asencio
- Daniel Muñoz

# Distribució del treball :bookmark_tabs:
- Luca Bulla s'ha encarregat de crear el GitHub, tant projecte, issues. També s'ha encarregat de connectar amb en el SonarCloud
- Maria Baos s'ha encarregat de fer la definició de classes, classes de equivalència, valors límits i casos de prova. També s'ha encarregat de gestionar el readme.
- Hugo Asencio s'ha encarregat de refactoritzar el codi, utilitzant les bones pràctiques apreses a classe, treien línies de codi que no s'usen, deixant el codi sense parts duplicades i optimitzant-lo.
- Daniel Muñoz s'ha encarregat de fer el projecte de xUnit amb la seva llibreria corresponent, per a què els tests fets gràcies als casos de proves, funcionin correctament.

# Bloc de codi del programa :pushpin:
```C#
using System.Data;

namespace xUnitTestLibrary
{
    public static class TestsLibrary
    {
        public static int SumNumbers(int firstValue, int secondValue, int thirdValue)
        {

            if (firstValue <= 0) return 0;

            if (secondValue <= 0) return firstValue;

            if (thirdValue <= 0) return firstValue + secondValue;

            return firstValue + secondValue + thirdValue;
        }

        public static string DescriptionResult(int result)
        {
            const string EqualZero = "El resultat és zero.";
            const string PositiveResult = "El resultat és positiu.";
            const string NegativeResult = "El resultat és negatiu.";

            if (result == 0) return EqualZero;
            if (result > 0) return PositiveResult;
            return NegativeResult;
        }
    }
}

```

# Definició de clases i casos de prova :open_file_folder::microscope:
## 🧪 Casos de prova

| Cas | Nom cas prova | Descripció | Entrada | Accions | Resultats Esperats | Resultat obtingut |
|-----|----------------|-------------|----------|----------|---------------------|-------------------|
| **CP1 (Normal)** | Verificar les regles | Comprobar que s'obté el resultat esperat segons les regles | a = 5<br>b = 8<br>c = 10 | Introduir les dades necessaries | Result → a + b + c<br>Missatge → El resultat és positiu | “ “ |
| **CP2 (Límit)** | Verificar les regles | Comprobar que s'obté el resultat esperat segons les regles | a = 20<br>b = 3<br>c = 0 | Introduir les dades necessaries | Result → a + b<br>Missatge → El resultat és positiu | “ “ |
| **CP3 (Normal)** | Verificar les regles | Comprobar que s'obté el resultat esperat segons les regles | a = 10<br>b = -2<br>c = 3 | Introduir les dades necessaries | Result → a<br>Missatge → El resultat és positiu | “ “ |
| **CP4 (Límit)** | Verificar les regles | Comprobar que s'obté el resultat esperat segons les regles | a = 0<br>b = -10<br>c = 25 | Introduir les dades necessaries | Result → 0<br>Missatge → El resultat és zero | “ “ |
| **CP5 (Normal)** | Verificar les regles | Comprobar que s'obté el resultat esperat segons les regles | a = -10<br>b = 200<br>c = 3 | Introduir les dades necessaries | Result → 0<br>Missatge → El resultat és zero | “ “ |

---

## 🧩 Classes d’equivalència

| Classe de equivalència | Regles | Result | Missatge |
|--------------------------|---------|---------|-----------|
| **Classe 1** | a > 0, b > 0 i c > 0 | a + b + c | El resultat és positiu |
| **Classe 2** | a > 0, b > 0 i c < 0 | a + b | El resultat és positiu |
| **Classe 3** | a > 0 i b < 0 | a | El resultat és positiu |
| **Classe 4** | a < 0 | 0 | El resultat és negatiu o El resultat és zero |

---

## ⚙️ Valors límit
Regles = (a > 0, b > 0 i c > 0), (a > 0, b > 0 i c < 0) →Frontera a + b + c - El resultat és positiu  
Regles = (a > 0, b > 0 i c < 0), (a > 0 i b < 0) → Frontera a + b - El resultat és positiu  
Regles = (a > 0 i b < 0), (a < 0) → Frontera a - El resultat és negatiu o zero  


# Test Unitaris (XUnit) :memo:
## Documentació
Primer creem un projecte nou de xUnit (C#) a Visual Studio. 
Seguidament, posem un nou projecte a la solució que ja tenim. Aquest nou projecte será de tipus Class Library, on posarem en codi les operacions que volguem retornant el resultat que agadará el xUnit.
Abans de fer res al xUnit, s'ha de afegir la dependecia de la Library.
Ara, fent us de la Library amb "using {namespaceLibrary}", ja podriem trucar a les funcions, però abans, hem de obtar per quina manera volem executar el test, ja sigui and  [Fact] o amd [Theory]. A difèrencia d'un Fact, un Theory permet executar el mateix test varies vegadas, però amb diferents conjunts de dades. També es pot utilitzar per provar un mateix mètode baix diferents condicions.

```C#
using Xunit;
using xUnitTestLibrary;

namespace xUnitTests
{
    public class IntegracioContinuaTests
    {
        [Theory]
        [InlineData(5, 8, 10, (5+8+10), "El resultat és positiu.")]
        [InlineData(20, 3, 0, (20+3), "El resultat és positiu.")]
        [InlineData(10, -2, 3, (10), "El resultat és positiu.")]
        [InlineData(0, -10, 25, (0), "El resultat és zero.")]
        [InlineData(-10, 200, 3, (0), "El resultat és zero.")]

        public void TC1_Add_Numbers(int firstNum, int secondNum, int thirdNum, int expectedResultInt, string expectedResultString)
        {
            //Arrange
            int result;
            string actualString;

            //Act
            result = TestsLibrary.SumNumbers(firstNum, secondNum, thirdNum);
            actualString = TestsLibrary.DescriptionResult(result);

            //Assert
            Assert.Equal(expectedResultInt, result);
            Assert.Equal(expectedResultString, actualString);
        }
    }
}

```
# Configuració i funcionament de l'entorn :chart_with_upwards_trend:

# Respostes preguntes :page_facing_up:
- Pregunta 1: En aquest anàlisi inicial del programa, es mostren resultats en l’apartat de cobertura de codi (coverage)? Raoneu la vostra resposta, incloent una captura de la pantalla de resum de SonarCloud.
    - 
- Pregunta 2: Quines accions heu realitzat per reduir la complexitat ciclomàtica?  Raoneu la vostra resposta.
    - 
- Pregunta 3: Com separaríeu la lògica de càlcul en mètodes independents?  Raoneu la vostra resposta.
    - Jo ho separaria en dos mètodes, el primer fa el càlcul de sumar i l'altre em retorna un string que hauria d'imprimir per pantalla segons el càlcul de la suma.
- Pregunta 4: Es poden passar tots els tests correctament? Com es captura la sortida per consola? Raoneu la vostra resposta i poseu algun exemple on ho heu implementat.   
    - Sí, tots els tests han passat perfectament sense cap mena de problema. El resultat per consola, en el nostre cas, ens diu que: El procés de compilació es va iniciar a les 10:19 i va generar els fitxers .dll per als projectes "xUnitTestLibrary" i "xUnitTests" a les carpetes corresponents. Tots dos projectes es van compilar amb èxit, amb la configuració Debug per a Any CPU. El procés de compilació va acabar a les 10:20 i va durar 20,745 segons. Un exemple del test amb èxit: xUnitTests.IntegracioContinuaTests.TC1_Add_Numbers(firstNum: 0, secondNum: -10, thirdNum: 25, expectedResultInt: 0, expectedResultString: "El resultat és zero.")
- Pregunta 5: Quin error ha estat més difícil/complex de solucionar? Raoneu la vostra resposta i poseu algun exemple on ho heu implementat.
    - 
  
# IA Consultada :crystal_ball:
- IA: ChatGpt
- Prompt: Hola chat!! Tengo que pasar las siguientes tablas para un markdown de github, me podrias ayudar? Es estas tablas siguientes: Casos de prova Cas Nom cas prova Descripción Entrada Accions Resultats Esperats Resultat obtingut CP1 (Normal) Verificar les regles Comprobar que s'obté el resultat esperat segons les regles a = 5 b = 8 c = 10 Introduir les dades necessaries Result -> a + b + c Missatge -> El resultat és positiu “ “ CP2 (Limit) Verificar les regles Comprobar que s'obté el resultat esperat segons les regles a = 20 b = 3 c = 0 Introduir les dades necessaries Result -> a + b Missatge -> El resultat és positiu “ “ CP3 (Normal) Verificar les regles Comprobar que s'obté el resultat esperat segons les regles a = 10 b = -2 c = 3 Introduir les dades necessaries Result -> a Missatge -> El resultat és positiu “ “ CP4 (Limit) Verificar les regles Comprobar que s'obté el resultat esperat segons les regles a = 0 b = -10 c = 25 Introduir les dades necessaries Result -> 0 Missatge -> El resultat és zero “ “ CP5 (Normal) Verificar les regles Comprobar que s'obté el resultat esperat segons les regles a = -10 b = 200 c = 3 Introduir les dades necessaries Result -> a Missatge -> El resultat és negatiu “ “ Clases d’equivalencia Classe de equivalencia Regles Result Missatge Classe 1 a > 0, b > 0 i c > 0 a + b + c El resultat és positiu Classe 2 a > 0, b > 0 i c < 0 a + b El resultat és positiu Classe 3 a > 0 i b < 0 a El resultat és positiu Classe4 a < 0 0 El resultat és negatiu o El resultat és zero Valors limits Regles = (a > 0, b > 0 i c > 0), (a > 0, b > 0 i c < 0) →Frontera a + b + c - El resultat és positiu Regles = (a > 0, b > 0 i c < 0), (a > 0 i b < 0) → Frontera a + b - El resultat és positiu Regles = (a > 0 i b < 0), (a < 0) → Frontera a - El resultat és negatiu o zero
  
- Resposta: Perfecto 😊 Te paso todas tus tablas bien formateadas para **Markdown de GitHub**, listas para copiar y pegar.
---

## 🧪 Casos de prova

| Cas              | Nom cas prova        | Descripció                                                 | Entrada                     | Accions                         | Resultats Esperats                                      | Resultat obtingut |
| ---------------- | -------------------- | ---------------------------------------------------------- | --------------------------- | ------------------------------- | ------------------------------------------------------- | ----------------- |
| **CP1 (Normal)** | Verificar les regles | Comprobar que s'obté el resultat esperat segons les regles | a = 5<br>b = 8<br>c = 10    | Introduir les dades necessaries | Result → a + b + c<br>Missatge → El resultat és positiu | “ “               |
| **CP2 (Límit)**  | Verificar les regles | Comprobar que s'obté el resultat esperat segons les regles | a = 20<br>b = 3<br>c = 0    | Introduir les dades necessaries | Result → a + b<br>Missatge → El resultat és positiu     | “ “               |
| **CP3 (Normal)** | Verificar les regles | Comprobar que s'obté el resultat esperat segons les regles | a = 10<br>b = -2<br>c = 3   | Introduir les dades necessaries | Result → a<br>Missatge → El resultat és positiu         | “ “               |
| **CP4 (Límit)**  | Verificar les regles | Comprobar que s'obté el resultat esperat segons les regles | a = 0<br>b = -10<br>c = 25  | Introduir les dades necessaries | Result → 0<br>Missatge → El resultat és zero            | “ “               |
| **CP5 (Normal)** | Verificar les regles | Comprobar que s'obté el resultat esperat segons les regles | a = -10<br>b = 200<br>c = 3 | Introduir les dades necessaries | Result → 0<br>Missatge → El resultat és zero         | “ “               |

---

## 🧩 Classes d’equivalència

| Classe de equivalència | Regles               | Result    | Missatge                                     |
| ---------------------- | -------------------- | --------- | -------------------------------------------- |
| **Classe 1**           | a > 0, b > 0 i c > 0 | a + b + c | El resultat és positiu                       |
| **Classe 2**           | a > 0, b > 0 i c < 0 | a + b     | El resultat és positiu                       |
| **Classe 3**           | a > 0 i b < 0        | a         | El resultat és positiu                       |
| **Classe 4**           | a < 0                | 0         | El resultat és negatiu o El resultat és zero |

---

## ⚙️ Valors límit

| Regles                                         | Frontera  | Resultat esperat              |
| ---------------------------------------------- | --------- | ----------------------------- |
| (a > 0, b > 0 i c > 0), (a > 0, b > 0 i c < 0) | a + b + c | El resultat és positiu        |
| (a > 0, b > 0 i c < 0), (a > 0 i b < 0)        | a + b     | El resultat és positiu        |
| (a > 0 i b < 0), (a < 0)                       | a         | El resultat és negatiu o zero |

---

¿Quieres que te lo formatee también en **HTML** para incluirlo directamente en una web o README con estilos (por ejemplo, bordes o colores)?

- Enllaç: https://chatgpt.com/share/694000eb-db60-8010-b663-4cb9b910e41e

