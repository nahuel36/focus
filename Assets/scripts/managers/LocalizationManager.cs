using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public static class LocalizationManager {


    public enum words{
        menu_start,
        menu_best_time,
        menu_extras,

        extras_achievements,
        extras_style,
        extras_getcoins,
        extras_back,

        style_changebackground,
        style_changeball,
        style_removebanner,

        achiv_30seconds,
        achiv_60seconds,
        achiv_120seconds,
        achiv_300seconds,
        achiv_1ponged,
        achiv_2ponged,
        achiv_3ponged,
        achiv_galaxy,
        achiv_smoke,
        achiv_spin,

        achiv_30seconds_description,
        achiv_60seconds_description,
        achiv_120seconds_description,
        achiv_300seconds_description,
        achiv_1ponged_description,
        achiv_2ponged_description,
        achiv_3ponged_description,
        achiv_galaxy_description,
        achiv_smoke_description,
        achiv_spin_description,

        game_focus_on_ball,
        game_dont_let_it_fall,
        game_move_finger,
        game_make_best_time,
        game_hold_here,
        game_achievement_unlocked,

        results_you_loose,
        results_your_time,
        results_best_time,
        results_continue,
		results_share,
        results_restart,

        stop_tokeep,
        stop_watch,

        coinsadvice_toget,
        coinsadvice_buy,
        coinsadvice_ok,

        coinsmenu_pack1,
        coinsmenu_pack2,
        coinsmenu_pack3,

        confirmation_tocontinue,
        confirmation_yes,
        confirmation_no,

        continuein_continue_in,
    };
    static Dictionary<words,string> language;
     
    


    // Use this for initialization
    public static void Initialize ()
    {
        language = new Dictionary<words, string>();

		if (Application.systemLanguage == SystemLanguage.Spanish)
			AddWords ("es");
		else if (Application.systemLanguage == SystemLanguage.Portuguese)
			AddWords ("pt");
		else 
			AddWords ("en");

    }

    static void AddWords(string lang)
    {
        if (lang == "en")
        {
            language.Add(words.menu_start, "Start");
            language.Add(words.menu_best_time, "best time");
            language.Add(words.menu_extras, "Extras");

            language.Add(words.extras_achievements, "thropies");///////////////
            language.Add(words.extras_style, "style");
            language.Add(words.extras_getcoins, "buy coins");
            language.Add(words.extras_back, "back");


            language.Add(words.style_changebackground, "change background");
            language.Add(words.style_changeball, "change ball");
            language.Add(words.style_removebanner, "remove banner");

            language.Add(words.achiv_30seconds, "30 seconds");
            language.Add(words.achiv_60seconds, "60 seconds");
            language.Add(words.achiv_120seconds, "120 seconds");
            language.Add(words.achiv_300seconds, "300 seconds");
            language.Add(words.achiv_1ponged, "first slow ball");
            language.Add(words.achiv_2ponged, "second slow ball");
            language.Add(words.achiv_3ponged, "third slow ball");
            language.Add(words.achiv_galaxy, "galaxy");
            language.Add(words.achiv_smoke, "smoke");
            language.Add(words.achiv_spin, "spin");
            language.Add(words.achiv_30seconds_description, "survive 30 seconds");
            language.Add(words.achiv_60seconds_description, "survive 60 seconds");
            language.Add(words.achiv_120seconds_description, "survive 120 seconds");
            language.Add(words.achiv_300seconds_description, "survive 300 seconds");
            language.Add(words.achiv_1ponged_description, "your first slow ball");
            language.Add(words.achiv_2ponged_description, "do two slow balls in a row");
            language.Add(words.achiv_3ponged_description, "do three slow balls in a row");
            language.Add(words.achiv_galaxy_description, "survive 5 seconds in the galaxy");
            language.Add(words.achiv_smoke_description, "survive 5 seconds with smoke");
            language.Add(words.achiv_spin_description, "survive 5 seconds in spin");

            language.Add(words.game_focus_on_ball, "look at the ball");
            language.Add(words.game_dont_let_it_fall, "dont let it fall");
            language.Add(words.game_move_finger, "move your finger");
            language.Add(words.game_make_best_time, "make your best time");
            language.Add(words.game_hold_here, "hold here");
            language.Add(words.game_achievement_unlocked, "thropie unlocked");//////////////////


            language.Add(words.results_you_loose, "end");
            language.Add(words.results_restart, "restart");
            language.Add(words.results_your_time, "time");
            language.Add(words.results_best_time, "best time");
			language.Add(words.results_share, "Share");
            language.Add(words.results_continue, "Continue");

            language.Add(words.stop_tokeep, "To keep playing watch a video or wait");
            language.Add(words.stop_watch, "watch");

            language.Add(words.coinsadvice_toget, "get coins ingame, they are rewards of differents achievements");
            language.Add(words.coinsadvice_buy, "buy");
            language.Add(words.coinsadvice_ok, "ok");

            language.Add(words.coinsmenu_pack1, "10 coins");
            language.Add(words.coinsmenu_pack2, "25 coins");
            language.Add(words.coinsmenu_pack3, "40 coins");

            language.Add(words.confirmation_tocontinue, "you can use 5 coins to continue this life");
            language.Add(words.confirmation_yes, "ok");
            language.Add(words.confirmation_no, "no,thanks");

            language.Add(words.continuein_continue_in, "continue in...");
        }
        else if (lang == "es")
        {
            language.Add(words.menu_start, "Jugar");
            language.Add(words.menu_best_time, "mejor tiempo");
            language.Add(words.menu_extras, "Extras");

            language.Add(words.extras_achievements, "trofeos");
            language.Add(words.extras_style, "estilo");
            language.Add(words.extras_getcoins, "comprar monedas");
            language.Add(words.extras_back, "volver");


            language.Add(words.style_changebackground, "cambiar fondo");
            language.Add(words.style_changeball, "cambiar bola");
            language.Add(words.style_removebanner, "sacar banner");

            language.Add(words.achiv_30seconds, "30 segundos");
            language.Add(words.achiv_60seconds, "60 segundos");
            language.Add(words.achiv_120seconds, "120 segundos");
            language.Add(words.achiv_300seconds, "300 segundos");
            language.Add(words.achiv_1ponged, "primer bola lenta");
            language.Add(words.achiv_2ponged, "segunda bola lenta");
            language.Add(words.achiv_3ponged, "tercer bola lenta");
            language.Add(words.achiv_galaxy, "galaxia");
            language.Add(words.achiv_smoke, "humo");
            language.Add(words.achiv_spin, "remolino");
            language.Add(words.achiv_30seconds_description, "sobrevive 30 segundos");
            language.Add(words.achiv_60seconds_description, "sobrevive 60 segundos");
            language.Add(words.achiv_120seconds_description, "sobrevive 120 segundos");
            language.Add(words.achiv_300seconds_description, "sobrevive 300 segundos");
            language.Add(words.achiv_1ponged_description, "tu primer bola lenta");
            language.Add(words.achiv_2ponged_description, "dos bolas lentas seguidas");
            language.Add(words.achiv_3ponged_description, "tres bolas lentas seguidas");
            language.Add(words.achiv_galaxy_description, "sobrevive 5 segundos a la galaxia");
            language.Add(words.achiv_smoke_description, "sobrevive 5 segundos al humo");
            language.Add(words.achiv_spin_description, "sobrevive 5 segundos al remolino");

            language.Add(words.game_focus_on_ball, "mira la pelota");
            language.Add(words.game_dont_let_it_fall, "no dejes que caiga");
            language.Add(words.game_move_finger, "muevete!");
            language.Add(words.game_make_best_time, "haz tu mejor tiempo");
            language.Add(words.game_hold_here, "presiona");
            language.Add(words.game_achievement_unlocked, "trofeo conseguido");
            
            language.Add(words.results_you_loose, "fin");
            language.Add(words.results_your_time, "tu tiempo");
            language.Add(words.results_best_time, "el mejor");
            language.Add(words.results_continue, "Continuar");
			language.Add(words.results_share, "Compartir");
            language.Add(words.results_restart, "reintentar");

            language.Add(words.stop_tokeep, "Para seguir jugando mira un video o espera");
            language.Add(words.stop_watch, "mirar");

            language.Add(words.coinsadvice_toget, "obten monedas mientras juegas, son recompensas de distintos logros");
            language.Add(words.coinsadvice_buy, "comprar");
            language.Add(words.coinsadvice_ok, "ok");

            language.Add(words.coinsmenu_pack1, "10 monedas");
            language.Add(words.coinsmenu_pack2, "25 monedas");
            language.Add(words.coinsmenu_pack3, "40 monedas");

            language.Add(words.confirmation_tocontinue, "puedes continuar esta vida usando 5 monedas");
            language.Add(words.confirmation_yes, "ok");
            language.Add(words.confirmation_no, "no,gracias");

            language.Add(words.continuein_continue_in, "continuando en...");

        }
        else if (lang == "pt")
		{
            language.Add(words.menu_start, "Jogar");
            language.Add(words.menu_best_time, "melhor tempo");
            language.Add(words.menu_extras, "Extras");
            
            language.Add(words.extras_achievements, "troféus");
            language.Add(words.extras_style, "estilo");
            language.Add(words.extras_getcoins, "comprar moedas");//////////////////////////////
            language.Add(words.extras_back, "volver");/////////////////////////////////////////

            language.Add(words.style_changebackground, "mudar fundo");
            language.Add(words.style_changeball, "mudar bola");
            language.Add(words.style_removebanner, "sacar banner");////////////////////////////


            ////////////////////////////////////////////////////////////////////////
            language.Add(words.achiv_30seconds, "30 segundos");
            language.Add(words.achiv_60seconds, "60 segundos");
            language.Add(words.achiv_120seconds, "120 segundos");
            language.Add(words.achiv_300seconds, "300 segundos");
            language.Add(words.achiv_1ponged, "primeiro bola lenta");
            language.Add(words.achiv_2ponged, "duas bolas lentas");
            language.Add(words.achiv_3ponged, "três bolas lentas");
            language.Add(words.achiv_galaxy, "galaxia");
            language.Add(words.achiv_smoke, "fumaça");
            language.Add(words.achiv_spin, "redemoinho");
            language.Add(words.achiv_30seconds_description, "tens passado os 30 segundos");
            language.Add(words.achiv_60seconds_description, "tens passado os 60 segundos");
            language.Add(words.achiv_120seconds_description, "tens passado os 120 segundos");
            language.Add(words.achiv_300seconds_description, "tens passado os 300 segundos");
            language.Add(words.achiv_1ponged_description, "primeiro bola lenta");
            language.Add(words.achiv_2ponged_description, "duas bolas lentas seguidas");
            language.Add(words.achiv_3ponged_description, "três bolas lentas seguidas");
            language.Add(words.achiv_galaxy_description, "sobreviveste 5 segundos à galaxia");
            language.Add(words.achiv_smoke_description, "sobreviveste 5 segundos à fumaça");
            language.Add(words.achiv_spin_description, "sobreviveste 5 segundos ao redemoinho");
            ////////////////////////////////////////////////////////////////////////


            language.Add(words.game_focus_on_ball, "olha a pelota");
            language.Add(words.game_dont_let_it_fall, "não deixe que caia");
            language.Add(words.game_move_finger, "mova seu dedo");
            language.Add(words.game_make_best_time, "faça seu melhor tempo");
            language.Add(words.game_hold_here, "pressiona");
            language.Add(words.game_achievement_unlocked, "trofeo conseguido");//////////////////


            language.Add(words.results_you_loose, "fim");
            language.Add(words.results_your_time, "seu tempo");
            language.Add(words.results_best_time, "o melhor");
            language.Add(words.results_continue, "Continuar");
            language.Add(words.results_share, "Compartilhar");
            language.Add(words.results_restart, "recomeçar");

            language.Add(words.stop_tokeep, "Para seguir jogando olha um video ou espera");
            language.Add(words.stop_watch, "ver");

            language.Add(words.coinsadvice_toget, "obten moedas enquanto jogas, são recompensas de diferentes conquistas");
            language.Add(words.coinsadvice_buy, "comprar");
            language.Add(words.coinsadvice_ok, "ok");

            language.Add(words.coinsmenu_pack1, "10 moedas");
            language.Add(words.coinsmenu_pack2, "25 moedas");
            language.Add(words.coinsmenu_pack3, "40 moedas");

            language.Add(words.confirmation_tocontinue, "podes continuar esta vida usando 5 moedas");
            language.Add(words.confirmation_yes, "ok");
            language.Add(words.confirmation_no, "não,obrigado");

            language.Add(words.continuein_continue_in, "continuando em...");
        }
    }

    // Update is called once per frame
    public static string GetWord (words word) {
        string out_word;
        if (language.TryGetValue(word, out out_word))
            return out_word;
        else return "";
	}
}
