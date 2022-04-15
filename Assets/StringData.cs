using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringData : MonoBehaviour
{

    //strings for all Versions (Experiment1, Experiment2, Kontrolle)
    public readonly string sDatenschutzReplacement = "<b>Herzlich willkommen zum heutigen Experiment!</b>\n\nVielen Dank, dass " +
    "Sie sich die Zeit nehmen und uns so tatkräftig mit Ihrer Teilnahme unterstützen. " +
    "Bitte lesen Sie sich einmal alles in Ruhe durch und folgen Sie den Anweisungen auf den jeweiligen Seiten.\n\nSie können nun gerne beginnen!";


    //strings for Experiment 1
    public readonly string sPsychoedukativeReplacementV1 = "Erklärung zu \"ungünstigen\" Gedanken\n\nPersonen, greifen häufig auf \"ungünstige\", \"ungünstige\" Gedanken," +
        " sog. dysfunktionale Annahmen zurück, wenn es darum geht, wie sie sich selber (und besonders ihr Körperbild) wahrnehmen. \"ungünstige\" Gedanken" +
        " stellen einen zentralen Ansatzpunkt in der Psychotherapie dar.\n\nWir möchten im Rahmen unserer Studie \"ungünstige\" Gedanken bearbeiten. Dabei " +
        "werden Sie durch eine virtuelle Person (sog. virtueller Agent) mit Ihren \"ungünstigen\" Gedanken konfrontiert. Es wird hierbei geübt, dem Agenten" +
        " zu widersprechen. Die Studie zielt darauf ab, \"ungünstige\" Gedanken zu minimieren und gleichzeitig \"gute\", sog. funktionale Annahmen, zu fördern.";

    public readonly string sBeispielDysGedReplacementV1 = "Bitte geben Sie Ihren \"ungünstigen\" und den dazugehörigen \"guten\", alternativen Gedanken ein.\n\nAchten Sie darauf den \"ungünstigen\" Gedanken in der \"<b><color=red>Du-Form</b></color>\" zu formulieren.\n\n" +
        "Den \"guten\" Gedanken formulieren Sie in der \"<b><color=red>Ich-Form</color></b>\".";//"Wir möchten Ihnen gerne ein Beispiel für \"ungünstige\" und \"gute\" Gedanken geben.\n\nBeispiel für ungünstigen Gedanken:\n\n\"Wenn ich abnehme, interessieren sich die anderen mehr für mich.\"" +
        //"\n\n\n\nBeispiel für \"guten\" Gedanken:\n\n\"Ich muss nicht perfekt sein, um von anderen gemocht zu werden.\"";

    public readonly string sInstruktionIndivReplacementV1 = "Bitte überlegen Sie sich drei \"ungünstige\" körperbezogene Gedanken, die Sie für sich als zutreffend empfinden sowie drei dazugehörige \"gute\" "+
         "Gedanken. Bitte geben Sie die \"ungünstigen\" Gedanken in <b>DU-Botschaften</b> und ihre widersprechenden \"guten\" Gedanken in <b>ICH-Botschaften</b> an!\n\n" +
        "Bitte beachten Sie, dass Ihre Gedanken nur im Rahmen dieser Studie verwendet werden, <color=red>streng vertraulich</color> behandelt werden und nicht Ihrer Person zuordenbar sind.";

    public readonly string sFormulierungGedankenBeispielV1 = "Bitte geben Sie Ihren \"ungünstigen\" und den dazugehörigen \"guten\", alternativen Gedanken ein.\n\nAchten Sie darauf, den \"ungünstigen\" Gedanken in der <b><color=red>Du-Form</color></b> zu formulieren.\n\n" +
        "Den \"guten\" Gedanken formulieren Sie in der <b><color=red>Ich-Form</color></b>.";/*"Zur Erinnerung noch einmal ein Beispiel.\n\n\"ungünstiger\" Gedanke: z.B. \"<color=red>Du</color> bist attraktiver, wenn dein Bauch flach ist.\" " +
        "\"Guter\" Gedanke: z.B. \"Das stimmt nicht, <color=red>ich</color> bin perfekt und zufrieden wie ich bin.\"";*/

    public readonly string sHilfeV1 = "<b><size=20>Hilfebereich</size></b>\n\n<b>Hier findest Du nochmal ein paar Beispiele, an denen Du Dich gerne orientieren kannst.</b>\n\n" +
        "<i>Du musst mehr Sport machen, damit Du nicht (weiter) zunimmst.\n\nDein Körper ist unattraktiv.\n\nDu musst weniger essen, um nicht noch dicker zu werden.\n\n" +
        "Du hast dich beim Essen überhaupt nicht unter Kontrolle.\n\nDu musst unbedingt wieder eine Diät machen und abnehmen.\n\nDu solltest beim Einkaufen mehr auf die Nährwerte achten.\n\n" +
        "Du könntest muskulöser sein.\n\nDu siehst (wieder) so aufgebläht aus.\n\nWenn Du nicht in diese Hose passt, bist Du wertlos.\n\nWenn Du die Diät nicht schaffst, bist Du ein/-e VersagerIn.\n\n" +
        "Du musst auch so einen schlanken Körper haben wie andere.\n\nWenn Du schon wieder so ungesunde Sachen isst, wird deine Haut unrein.\n\nDu wirst mehr geliebt, wenn Du schlanker bist.\n\n" +
        "Du hast heute schon genug Kalorien zu Dir genommen.\n\nDu darfst nicht mehr.\n\nDein Bauch ist nicht flach genug und Dein Po müsste größer sein.\n\nDu brauchst unbedingt neue Kleidung," +
        " die Deine Makel kaschieren.\n\n</i>";

    public readonly string sAufklaerungVersuchV1 = "In der Folge gibt es 3 Durchgänge, in denen Sie mit Ihren drei ungünstigen Gedanken konfrontiert werden und diesen mit Ihren guten Gedanken widersprechen. Die Reihenfolge der ungünstigen Gedanken bleibt dabei immer gleich (1,2,3).";/*Wir möchten Sie kurz über den Ablauf der Sitzung aufklären. Es besteht zuerst die Möglichkeit den Ablauf der Konfrontation anhand eines" +
        " Probedurchgangs zu üben.\n"In der Folge gibt es 3 Durchgänge, in denen Sie mit Ihren drei guten Gedanken konfrontiert werden und diesen wiedersprechen sollen. Die Reihenfolge" +
        " der positiven Gedanken bleibt dabei immer gleich (1,2,3).";*/

    public readonly string sNebenwirkungenV1 = "Nebenwirkungen\n\nBitte beachten Sie, dass im Rahmen der Studie einige Nebenwirkungen nicht vollkommen ausgeschlossen werden können.\n" +
       "Da in unserer Studie \"ungünstige\" Gedanken bearbeitet werden, kann es sein, dass Sie dies zwischenzeitlich als unangenehm empfinden. Bitte beachten Sie, dass negative Gefühle" +
       " normale Reaktionen sind und vorübergehen. Sollten die Gefühle nicht vorübergehen, kontaktieren Sie bitte die Versuchsleiter.";

    public readonly string sSchwierigkeitstratingV1 = "<b><color=red>Schwierigkeitsrating</color></b>\n\nBitte geben Sie nun ein Rating darüber ab, wie schwer es Ihnen am Ende der Sitzung gefallen ist, dem virtuellen Agenten zu widersprechen.\n\nSkala von 0-100 (0 = gar nicht schwer; 100 = sehr schwer)";
    public readonly string sDysfunktionaleGedankenV1 = "<b>Überzeugung des <color=red>ungünstigen Gedankens</color></b>\n\nBitte geben Sie nun ein Rating darüber ab, wie überzeugt Sie davon sind, dass der jeweilige \"ungünstige\" Gedanke zutrifft.\n\nSkala von 0-100 (0 = gar nicht überzeugt; 100 = absolut überzeugt)\n\nBitte geben Sie ein separates Rating für jeden Ihrer drei \"ungünstigen\" Gedanken ab.";
    public readonly string sAlternativeGedankenV1 = "<b>Überzeugung des <color=red>guten Gedankens</color></b>\n\nBitte geben Sie nun ein Rating darüber ab, wie überzeugt Sie davon sind, dass der jeweilige alternative, \"gute\" Gedanke zutrifft.\n\nSkala von 0-100 (0 = gar nicht überzeugt; 100 = sehr überzeugt)\n\nBitte geben Sie ein separates Rating für jeden Ihrer drei \"guten\" Gedanken ab.";

    public readonly string sUebungstextVersuchV1 = "Beispielhafter Ablauf einer Konfrontation:\n\nSie werden mit ihren \"ungünstigen\" Gedanken der Reihe nach konfrontiert und widersprechen diesen mit ihren \"guten\" Gedanken.\n\n" +
        "Beispiel:\n\nAgent: \"Du wirst mehr geliebt, wenn Du schlanker bist.\"\n\nSie: \"Nein, das stimmt nicht. Ich muss nicht perfekt sein, um von anderen gemocht zu werden.\"";



    //strings for Experiment 2

    public readonly string sToggleTextV2 = "Ich habe zugestimmt";
    
    public readonly string sPsychoedukativeReplacementV2 = "Wirksamkeit positiver Gedanken\n\nPersonen greifen häufig auf \"ungünstige\", \"ungünstige\" Gedanken, sog. dysfunktionale Annahmen, zurück" +
        " insbesondere wenn es darum geht, wie sie sich selbst (und besonders Ihr Körperbild) wahrnehmen.\n\"ungünstige\" Gedanken stellen einen zentralen Ansatzpunkt in der Psychotherapie dar. " +
        "\n\nUm diese „ungünstigen“ Gedanken zu minimieren, wollen wir uns im Rahmen unserer Studie auf <b>\"positive\"</b>, <b>\"gute\"</b> Gedanken bezüglich unseres Körpers fokussieren. " +
        "Dabei werden Sie durch eine virtuelle Person (sog.virtueller Agent) mit Ihren „guten“ Gedanken konfrontiert. Ihre Aufgabe besteht darin, diesen Aussagen zuzustimmen.";


    public readonly string sBeispielDysGedReplacementV2 = "Wir möchten Ihnen gerne ein Beispiel für \"gute\" und \"ungünstige\" Gedanken geben.\n\nBeispiel für einen guten Gedanken:\n\n\"Mein Bauch ist schön so wie er ist.\"" +
       "\n\n\n\nBeispiel für einen \"ungünstigen\" Gedanken:\n\n\"Mein Körper ist unattraktiv.\"";

    public readonly string sInstruktionIndivReplacementV2 = "Bitte überlegen Sie sich drei \"gute\" und drei \"ungünstige\" Gedanken über ihren Körper, die Sie als zutreffend empfinden.\n\n" +
        "Bitte geben Sie Ihre Gedanken in <b>DU-Botschaften</b> an!\n\nZusätzlich formulieren Sie bitte zu jedem \"guten\" Gedanken eine \"Zustimmung\" in <b>ICH-Botschaften</b> (zur weiteren" +
        " Erklärung folgen Sie dem Beispiel auf der nächsten Seite).";

    public readonly string sFormulierungGedankenBeispielV2 = "Bitte geben Sie Ihren \"ungünstigen\" und den dazugehörigen \"guten\", alternativen Gedanken ein.\n\nAchten Sie darauf, den \"ungünstigen\" Gedanken in der <b><color=red>Du-Form</color></b> zu formulieren.\n\n" +
        "Den \"guten\" Gedanken formulieren Sie ebenfalls in der <b><color=red>Du-Form</color></b>.\n\nWiederholen Sie den \"guten\" Gedanken in <color=red><b>Ich-Form</b></color> (=Zustimmung).";/*"Zur Erinnerung noch einmal ein Beispiel.\n\n\"ungünstiger\" Gedanke: z.B. \"<color=red>Du</color> bist attraktiver, wenn dein Bauch flach ist.\" " +
    //"\"Guter\" Gedanke: z.B. \"<b>Dein</b> Bauch ist schön wie er ist.\"\n\"Zustimmung\" (in der <b>ICH-Botschaft</b>): \"Ja, das stimmt. Mein Bauch ist schön so wie er ist.\"";*/

    public readonly string sHilfeV2 = "<b><size=20>Hilfebereich</size></b>\n\n<b>Hier findest Du nochmal ein paar Beispiele für gute und ungünstige Gedanken, an denen Du dich orientieren kannst.</b>\n\n" +
    "<b>Gute Gedanken:</b>" +
        "\n\n<i>Deine Beine sind wohlgeformt und wunderschön." +
        "\n\nDein Körper ist attraktiv." +
        "\n\nDein Bauch ist gut so wie er ist." +
        "\n\nDein Po ist schön geformt." +
        "\n\nDu hast einen gutaussehenden Körper." +
        "\n\nDeine Arme sind toll durchtrainiert und muskulös." +
        "\n\nDu bist genau so richtig wie Du bist.</i>" +
        "\n\n\n<b>ungünstige Gedanken</b>" +
        "\n\n<i>Du musst mehr Sport machen, damit Du nicht (weiter) zunimmst." +
        "\n\nDein Körper ist unattraktiv." +
        "\n\nDu musst weniger essen, um nicht noch dicker zu werden." +
        "\n\nDu hast Dich beim Essen überhaupt nicht unter Kontrolle." +
        "\n\nDu musst unbedingt wieder eine Diät machen und abnehmen.</i>";


    public readonly string sAufklaerungVersuchV2 = "In der Folge gibt es 3 Durchgänge, in denen Sie mit Ihren drei guten Gedanken konfrontiert werden und diesen zustimmen sollen. Die Reihenfolge der positiven Gedanken bleibt dabei immer gleich (1,2,3).";



    public readonly string sSchwierigkeitstratingV2 = "<b><color=red>Schwierigkeitsrating</color></b>\n\nBitte geben Sie nun ein Rating darüber ab, wie schwer es Ihnen am Ende der Sitzung" +
        " gefallen ist, dem virtuellen Agenten zuzustimmen.\n\nSkala von 0-100 (0 = gar nicht schwer; 100 = sehr schwer)";

    public readonly string sDysfunktionaleGedankenV2 = "<b>Überzeugung des <color=red>ungünstigen Gedankens</color></b>\n\nBitte geben Sie nun ein Rating darüber ab, wie überzeugt Sie davon sind, dass der jeweilige \"ungünstige\" Gedanke zutrifft.\n\nSkala von 0-100 (0 = gar nicht überzeugt; 100 = absolut überzeugt)\n\nBitte geben Sie ein separates Rating für jeden Ihrer drei \"ungünstigen\" Gedanken ab.";
    //private string sAlternativeGedankenV2 = "Überzeugung des <color=red>guten Gedankens</color>\n\nBitte geben Sie nun ein Rating darüber ab, wie überzeugt Sie sind, dass der jeweilige alternative, \"gute\" Gedanke zutrifft.\n\nSkala von 0-100 (0 = gar nicht überzeugt; 100 = sehr überzeugt)\n\nBitte geben Sie ein separates Rating für jeden Ihrer drei \"guten\" Gedanken ab.";


    public readonly string sUebungstextVersuchV2 = "Beispielhafter Ablauf einer Konfrontation:\n\nSie werden mit ihren \"guten\" Gedanken der Reihe nach konfrontiert und stimmen diesen zu.\n\nBeispiel:\n\n" +
        "Agent: \"Dein Bauch sieht toll aus.\"\n\nSie: \"Ja, das stimmt. Mein Bauch sieht toll aus.\"";

    /* "Übungsdurchgang\n\nIn der Folge können Sie nun den Ablauf der Konfrontationen anhand eines Probedurchlaufes üben.\nBitte stimmen Sie der Aussage des Agenten zunächst zu und wiederholen Sie sie dann in einer ICH-Botschaft.\n\nBeispiel:\n\n" +
    "Agent: \"Dein Bauch sieht toll aus.\"\n\nSie: \"Ja, das stimmt. Mein Bauch sieht toll aus.\"";*/

    public readonly string sAlternativeGedankenV2 = "<b>Überzeugung des <color=red>guten Gedankens</color></b>\n\nBitte geben Sie nun ein Rating darüber ab, wie überzeugt Sie davon sind, dass der jeweilige alternative, \"gute\" Gedanke zutrifft.\n\nSkala von 0-100 (0 = gar nicht überzeugt; 100 = sehr überzeugt)\n\nBitte geben Sie ein separates Rating für jeden Ihrer drei \"guten\" Gedanken ab.";



    //strings for Kontrolle
    public readonly string sPsychoedukativeReplacementK = "Erklärung zu \"ungünstigen\" Gedanken\n\nPersonen greifen häufig auf \"ungünstige\", \"ungünstige\" Gedanken, sog. dysfunktionale Annahmen zurück," +
        " wenn es darum geht, wie sie sich selbst (undbesonders ihr Körperbild) wahrnehmen. \"ungünstige\" Gedanken stellen einen zentralen Ansatz in der Psychotherapie dar.\n\nWir möchten im Rahmen" +
        " unserer Studie \"ungünstige\" Gedanken bearbeiten und minimieren und gleichzeitig \"gute\" sog. funktionale Annahmen fördern.";

    public readonly string sBeispielDysGedReplacementK = "Wir möchten Ihnen gerne ein Beispiel für \"gute\" und \"ungünstige\" Gedanken geben.\n\nBeispiel für einen \"guten\" Gedanken:\n\n\"Mein Bauch ist schön so wie er ist.\"" +
   "\n\n\n\nBeispiel für einen \"ungünstigen\" Gedanken:\n\n\"Mein Körper ist unattraktiv.\"";

    public readonly string sInstruktionIndivReplacementK = "Bitte überlegen Sie sich drei \"gute\" und drei \"ungünstige\" Gedanken über ihren Körper, die Sie als zutreffend empfinden.\n\n" +
        "Bitte geben Sie die \"ungünstigen\" Gedanken in <color=red>DU</color>-Botschaften an!\n\n" +
        "Bitte beachten Sie, dass Ihre Gedanken nur im Rahmen dieser Studie verwendet werden, streng vertraulich behandelt werden und nicht ihrer Person zuordenbar sind.";//"Bitte geben Sie die \"ungünstigen\" Gedanken in <color=red><b>Du-Botschaften</b></color> an!\n\nBitte überlegen Sie sich drei \"gute\" und drei \"ungünstige\" Gedanken über ihren Körper, die Sie als zutreffend empfinden.";

    public readonly string sFormulierungGedankenBeispielK = "Bitte geben Sie Ihren \"ungünstigen\" und den dazugehörigen \"guten\", alternativen Gedanken ein.\n\nAchten Sie darauf, den \"ungünstigen\" Gedanken in der <b><color=red>Du-Form</color></b> zu formulieren.\n\n" +
        "Den \"guten\" Gedanken formulieren Sie in der <b><color=red>Ich-Form</color></b>.";//"Zur Erinnerung noch einmal ein Beispiel.\n\n\"ungünstiger\" Gedanke: z.B. \"Du bist attraktiver, wenn dein Bauch flach ist.\" " +
    //"\"Guter\" Gedanke: z.B. \"Du bist attraktiv so wie Du bist.\"";

    public readonly string sHilfeK = "<b><size=20>Hilfebereich</size></b>\n\n<b>Hier findest Du nochmal ein paar Beispiele für gute und ungünstige Gedanken, an denen Du dich orientieren kannst.</b>\n\n" +
    "<b>Gute Gedanken:</b>" +
        "\n\n<i>Deine Beine sind wohlgeformt und wunderschön." +
        "\n\nDein Körper ist attraktiv." +
        "\n\nDein Bauch ist gut so wie er ist." +
        "\n\nDein Po ist schön geformt." +
        "\n\nDu hast einen gutaussehenden Körper." +
        "\n\nDeine Arme sind toll durchtrainiert und muskulös." +
        "\n\nDu bist genau so richtig wie Du bist.</i>" +
        "\n\n\n<b>ungünstige Gedanken</b>" +
        "\n\n<i>Du musst mehr Sport machen, damit Du nicht (weiter) zunimmst." +
        "\n\nDein Körper ist unattraktiv." +
        "\n\nDu musst weniger essen, um nicht noch dicker zu werden." +
        "\n\nDu hast Dich beim Essen überhaupt nicht unter Kontrolle." +
        "\n\nDu musst unbedingt wieder eine Diät machen und abnehmen.</i>";

    public readonly string sNebenwirkungenK = "Nebenwirkungen\n\nBitte beachten Sie, dass im Rahmen der Studie einige Nebenwirkungen, wie beispielsweise unangenehme Gefühle, nicht vollkommen ausgeschlossen werden können.\n" +
    "Bitte beachten Sie, dass negative Gefühle normale Reaktionen sind und vorübergehen. Sollten die Gefühle nicht vorübergehen, kontaktieren Sie bitte die Versuchsleiter.";

    

    public readonly string sSchwierigkeitstratingK = "<color=red>Schwierigkeitsrating</color>\n\nBitte geben Sie nun ein Rating darüber ab, wie schwer es Ihnen am Ende der Sitzung gefallen ist, dem virtuellen Agenten zu widersprechen.\n\nSkala von 0-100 (0 = gar nicht schwer; 100 = sehr schwer)";
    public readonly string sDysfunktionaleGedankenK = "<b>Überzeugung des <color=red>ungünstigen Gedankens</color></b>\n\nBitte geben Sie nun ein Rating darüber ab, wie überzeugt Sie davon sind, dass der jeweilige \"ungünstige\" Gedanke zutrifft.\n\nSkala von 0-100 (0 = gar nicht überzeugt; 100 = absolut überzeugt)\n\nBitte geben Sie ein separates Rating für jeden Ihrer drei \"ungünstigen\" Gedanken ab.";
    public readonly string sAlternativeGedankenK = "<b>Überzeugung des <color=red>guten Gedankens</color></b>\n\nBitte geben Sie nun ein Rating darüber ab, wie überzeugt Sie davon sind, dass der jeweilige alternative, \"gute\" Gedanke zutrifft.\n\nSkala von 0-100 (0 = gar nicht überzeugt; 100 = sehr überzeugt)\n\nBitte geben Sie ein separates Rating für jeden Ihrer drei \"guten\" Gedanken ab.";




    /// <summary>
    /// Allgemeine Verabschiedungstexte
    /// </summary>
    public readonly string sVearbschiedung1 = "Unsere Umfrage ist hiermit für heute beendet. Vielen Dank für Ihre Geduld und Ihren wertvollen Beitrag zum Erfolg dieses Forschungsprojekts. Sie erhalten als nächstes eine E-Mail zum weiteren Ablauf der Studie von uns. Sie können nun dieses Browserfenster schließen.";
    public readonly string sVearbschiedung2 = "Unsere Umfrage ist hiermit für heute beendet. Vielen Dank für Ihre Geduld und Ihren wertvollen Beitrag zum Erfolg dieses Forschungsprojekts. Sie erhalten als nächstes eine E-Mail zum weiteren Ablauf der Studie von uns. Sie können nun dieses Browserfenster schließen.";
    public readonly string sVearbschiedung3 = "Der experimentelle Teil des Versuchs ist hiermit beendet.\nSie können nun dieses Browserfenster schließen.";/* "<color=red><b>Achtung!</b></color> Die heutige Sitzung ist noch nicht beendet. Die folgende Umfrage stellt den letzten Teil der Studie dar. Vielen Dank für Ihre Geduld und Ihren wertvollen Beitrag zum Erfolg dieses Forschungsprojekts. " +
        "Bitte klicken Sie hier, um weiter zur abschließenden Umfrage zu gelangen.";*/
}
