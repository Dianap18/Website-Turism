using TourismBackend.Models;

namespace TourismBackend.Data
{
    public static class DbSeeder
    {
        public static void Seed(TourismContext context)
        {
            // Verificăm dacă există deja date. Dacă da, nu mai facem nimic.
            if (context.Destinations.Any())
            {
                return;
            }

            var destinations = new List<Destination>
            {
                // 1. ROUTE 66 (USA)
                new Destination
                {
                    Slug = "route66",
                    Title = "Route 66, USA",
                    BannerImg = "/ruta66.jpeg",
                    Price = 100,
                    HotelUrl = "https://www.booking.com/hotel/us/budget-inn-barstow.ro.html?aid=304142&label=gen173nr-10CAso7AFCCHJvdXRlLTY2SDNYBGjAAYgBAZgBM7gBF8gBDNgBA-gBAfgBAYgCAagCAbgCh62FywbAAgHSAiQxNjZhYmI0Mi1iMjE4LTQwMmUtOTdmYi1jN2FhMzYzZjdkYzXYAgHgAgE&sid=f5bc3b3541918289922b34e594be1c20&all_sr_blocks=40566003_273500522_2_1_0&checkin=2026-01-13&checkout=2026-01-14&dest_id=20011511&dest_type=city&dist=0&group_adults=2&group_children=0&hapos=6&highlighted_blocks=40566003_273500522_2_1_0&hpos=6&matching_block_id=40566003_273500522_2_1_0&no_rooms=1&req_adults=2&req_children=0&room1=A%2CA&sb_price_type=total&sr_order=popularity&sr_pri_blocks=40566003_273500522_2_1_0__5366&srepoch=1768292468&srpvid=c6503aa15b2602bd&type=total&ucfs=1&",
                    Description = "Route 66 este mai mult decât un simplu drum; este o călătorie în timp prin inima Americii, simbolizând libertatea și spiritul de aventură. Cunoscută sub numele de „Main Street of America”, această șosea istorică leagă Chicago de Santa Monica, traversând opt state și oferind o privire nostalgică asupra unei epoci apuse, plină de motele cu neoane, benzinării retro și restaurante clasice de tip diner.\n\n" +
                                  "Pe parcursul călătoriei, vei descoperi peisaje schimbătoare, de la lanurile de porumb din Illinois la deșerturile aride din Arizona și Marele Canion. Este o experiență culturală unică, unde fiecare oprire spune o poveste despre migrația spre vest și visul american, oferind oportunități foto spectaculoase și întâlniri cu localnici primitori.",
                    Gallery = new List<DestinationImage>
                    {
                        new DestinationImage { Url = "/motel.jpeg" },
                        new DestinationImage { Url = "/route66map3.jpg" },
                        new DestinationImage { Url = "/rutamare.jpeg" },
                        new DestinationImage { Url = "/indieni.jpeg" },
                        new DestinationImage { Url = "/cadillax.jpeg" },
                        new DestinationImage { Url = "/canion.jpg" }
                    },
                    Reviews = new List<Review>() // Fara review-uri initiale
                },

                // 2. QUEBEC (CANADA)
                new Destination
                {
                    Slug = "quebec",
                    Title = "Quebec City, Canada",
                    BannerImg = "/quebec1.jpg",
                    Price = 210,
                    HotelUrl = "https://www.booking.com/hotel/ca/hilton-quebec.ro.html?aid=304142&label=gen173nr-10CAso7AFCCHJvdXRlLTY2SDNYBGjAAYgBAZgBM7gBF8gBDNgBA-gBAfgBAYgCAagCAbgCh62FywbAAgHSAiQxNjZhYmI0Mi1iMjE4LTQwMmUtOTdmYi1jN2FhMzYzZjdkYzXYAgHgAgE&sid=f5bc3b3541918289922b34e594be1c20&all_sr_blocks=4445873_381338385_2_42_0&checkin=2026-01-13&checkout=2026-01-14&dest_id=-571851&dest_type=city&dist=0&group_adults=1&group_children=0&hapos=2&highlighted_blocks=4445873_381338385_2_42_0&hpos=2&matching_block_id=4445873_381338385_2_42_0&nad_cpc=0.86&nad_id=fa9b036e-bbdd-4393-b78c-692afda9faf3_0&nad_placement=SR_MAIN&nad_track=eyJhdWN0aW9uRXBvY2giOjE3NjgyOTI1MzUzNzAsInJhbmsiOjEsImtvZGRpVHJhY2tpbmdJbmZvIjoiSWIzQ1VkVFRHWS9QWTZ6VERaWTJCM1NOZWhYZFZyUVgrcTR5WWp6VzdCMXJSU3ZkTWJzLy84TFEwTncybGd1YStuOExCdENoVEpSc2Y1YUNGNGptc004SEpKMU4zclowTHBxTTRVVE5GQWhnZEYrbkhvb25PcFZpUmNaR0VZNDdXMlIyQkF3VDB5ejV3bXRyWUJxMytlanpTSWZMVnRIT2gxT1ZuUVJ0T2FvdnNoVTVCcFg2KzViS3FWVC9KWThienowa1p3aVBKS28zODlyaUMzNjFmRHdyMEk2VHN0ZTcvVW0wNGM2UExGQklFbncvK0tCUnF1Z2Q3VE56bllrbzFnVEE4SThlY29LVnl6WkNHR3FWb3pvUlVaeXF1dGJuc3RlRTRJNENNdXdiQXMwaDVjZ3dyWWVCdkt6MDdnOVNnczB6aW4wZWM1bDJCQ1lTNFRvelpsTllzak9QUWh2YmtWMlhGblRTZ204MmZDYXJ6THRDZFlUOWpOdFMzWldiVEFEVWR6QlZwWTZFK3R4cy96T3RMazh3ZWZvMmt6YmpqenhXWjFlcWhuYjVJdDlYUnZaQndSMkdMTHhZY2lEdTk2SmpscC9FZFlqaGFYdnlrek1DTFRxOE5PMjBCeFYwa0RocFVNZk5ONDNtNU1XTjlTc2FQNVhsTE5RWGR3L25kaUFvMHVISTlBcWFtMTV1OHhCWEd4cDdUb3Q1WEIwTGhzYit5T0ZySmI5MFJhN3NhbDd5bUxETW9ROUFPNHN6YWdLMjVOZ0xCcXZqR295cnE5WUJhRDNkaUpvL1l6NnJDSlZ2eDVTUkdUa0tpaFVTa3ZhdjRpTnFVSFBHZ0VzREhib1dpWk94cUVyRzRXYytEc1hnbGRTc0N6aXlQSFhzQ2NMU3huSEsvRGhlK1gvSXhocnRxRGxCZi9BNnhQOVk4ZHc5VWV4T3NaUHZiN0RiOHNyWnFEak9sTmE3djhIOUVLaW1YZG80NVpqNHA2eE1rajlRdnFWMUdrcEd2OEhtZmRoUWlIWFRHbjdhSGRLVGFSSVZPUmlNMHNFaGtDVnlJRVhPVHRXakk2aXNQRTRFb3BVNmgyYkJKdU1SY1IzVm9HWVhTcnY3MXlMU3ZjeUJ0RjlSUm9rRnl2MTdZQ2dTd2JzTDJTRWhNQkQyT0VIOWN4MVJaMENpekt5VWN3RUFiOVJzeFphYUNPdUpXN2Fwd2ZaQzFBWVFHZmxHdDRYVGc1Y2dETDJmOGJOYTk3Mk9nZElFTkVzZjRaYUNoVlljUlZaczVneG9WT2xkT1BPQ01vK1ZqbDNLd09RLzJ0YmZwSERTWkVGdUFzSTk5dTlaK3crd29odkw4NlI3Y3FKNWdseVdXeXhXTDduOHlsY0Y1SHFxRElnSlU2UnYrT1dSMUVGelhEOGNqOUVFdU5VdkhpalJmZFprcHczNW9Meit5ak5LZ2xxd0FnWHVJTFpiWVhXWk50WmRDQWRNQWVVMjVzQ253V2hNM3Q2MDVMWk9icGRsdmNhREkxTUlKYUtlbHQzcmJObXRkUFZOd21wVHBrRGdoTG5MNFVNa05DTWlmTjJXUFNPOFJDZVJ1NmkwSVJKblIvRGNUSXB1eExybzhYaXJJVVVFRXlEU2ZsSHlIQ1EvdWNZNHY0VnhhZXoxbWhCVS85cXdMeUhSNXBxTXBHZUZrM3dKaTRWQ204UTB3SHYzSkVMbGlnMjAySWhONkhHaEZ1c3RzM1lrOVBHRlhVcDlGeUxtU2t0b3ZPaFBLZGxKVlBFYmtuMUcwWUdZNEdDaFhOQWkrZDV5WXQ2NUJrRHM4RGRubkJjS1lIN0lQNmF5ZW12UE41RU9CU01PenZ6bGJnMm9SNXUwMjhsaDc2bVZlV3V6eDM4RktWS1kwbGxtWitzODcwY09JWWxpRFVTd2Q0VHdVdUFQWlV0Q2o3ZjhzbU5YV1E0eUFpTkU0NzYydThyVTRqQkpqVFFwZFJweHFsYnBpaHVFdmVJOVdFVzFKQWVIU2xrPSJ9&no_rooms=1&req_adults=1&req_children=0&room1=A&sb_price_type=total&sr_order=popularity&sr_pri_blocks=4445873_381338385_2_42_0__26022&srepoch=1768292558&srpvid=d8213adb84c70467&type=total&ucfs=1&",
                    Description = "Quebec City este o bijuterie a Americii de Nord, fiind singurul oraș fortificat de pe continent la nord de Mexic. Cu străzile sale pietruite, arhitectura colonială franceză și celebrul Château Frontenac care domină orizontul, te vei simți ca și cum ai fi pășit într-un oraș european vechi. Centrul vechi (Vieux-Québec) este parte din patrimoniul UNESCO și emană un romantism aparte la fiecare colț.\n\n" +
                                  "Indiferent de anotimp, orașul oferă o atmosferă magică. Iarna, străzile se transformă într-un tărâm de basm în timpul Carnavalului de Iarnă, în timp ce vara terasele și festivalurile de stradă aduc o energie vibrantă. Bucătăria locală este un amestec rafinat de tradiții franceze și ingrediente locale.",
                    Gallery = new List<DestinationImage>
                    {
                        new DestinationImage { Url = "/quebec13.jpg" },
                        new DestinationImage { Url = "/quebec3.jpeg" },
                        new DestinationImage { Url = "/quebec8.jpg" },
                        new DestinationImage { Url = "/quebec4.jpeg" },
                        new DestinationImage { Url = "/quebec14.jpg" },
                        new DestinationImage { Url = "/quebec11.jpg" }
                    },
                    Reviews = new List<Review>()
                },

                // 3. GUANAJUATO (MEXIC)
                new Destination
                {
                    Slug = "guanajuato",
                    Title = "Guanajuato, Mexic",
                    BannerImg = "/guan0.png",
                    Price = 230,
                    HotelUrl = "https://www.booking.com/hotel/mx/nueve-25-guanajuato.ro.html?aid=304142&label=gen173nr-10CAso7AFCCHJvdXRlLTY2SDNYBGjAAYgBAZgBM7gBF8gBDNgBA-gBAfgBAYgCAagCAbgCh62FywbAAgHSAiQxNjZhYmI0Mi1iMjE4LTQwMmUtOTdmYi1jN2FhMzYzZjdkYzXYAgHgAgE&sid=f5bc3b3541918289922b34e594be1c20&all_sr_blocks=926333401_364418061_0_0_0&checkin=2026-01-13&checkout=2026-01-14&dest_id=-1669986&dest_type=city&dist=0&group_adults=1&group_children=0&hapos=1&highlighted_blocks=926333401_364418061_0_0_0&hpos=1&matching_block_id=926333401_364418061_0_0_0&no_rooms=1&req_adults=1&req_children=0&room1=A&sb_price_type=total&sr_order=popularity&sr_pri_blocks=926333401_364418061_0_0_0__387504&srepoch=1768293140&srpvid=6a7f3c05d2c40534&type=total&ucfs=1&#hotelTmpl",
                    Description = "Guanajuato este un oraș vibrant și plin de culoare, ascuns într-o vale îngustă din centrul Mexicului. Faimos pentru străzile sale labirintice, casele vopsite în nuanțe strălucitoare care urcă pe dealuri și istoria sa bogată legată de minele de argint, acest oraș este o explozie de cultură și artă. Teatrul Juarez și Universitatea din Guanajuato sunt doar câteva dintre punctele de reper arhitecturale impresionante.\n\n" +
                                  "Un aspect unic al orașului este rețeaua sa subterană de tuneluri, care fluidizează traficul pe sub centrul istoric. De asemenea, Guanajuato este gazda celebrului Festival Cervantino și locul nașterii muralistului Diego Rivera. Atmosfera este mereu animată de muzicienii mariachi și studenții care cântă în piețele publice.",
                    Gallery = new List<DestinationImage>
                    {
                        new DestinationImage { Url = "/guan1.jpg" },
                        new DestinationImage { Url = "/guan2.jpg" },
                        new DestinationImage { Url = "/guan3.jpg" },
                        new DestinationImage { Url = "/guan4.jpeg" },
                        new DestinationImage { Url = "/guan5.jpg" },
                        new DestinationImage { Url = "/guan6.jpg" }
                    },
                    Reviews = new List<Review>()
                },

                // 4. SANTORINI (GRECIA)
                new Destination
                {
                    Slug = "santorini",
                    Title = "Santorini, Grecia",
                    BannerImg = "/santorini0.jpg", 
                    Price = 190,
                    HotelUrl = "https://www.booking.com/hotel/gr/rocabella-resort-spa.ro.html?aid=304142&label=gen173nr-10CAso7AFCCHJvdXRlLTY2SDNYBGjAAYgBAZgBM7gBF8gBDNgBA-gBAfgBAYgCAagCAbgCh62FywbAAgHSAiQxNjZhYmI0Mi1iMjE4LTQwMmUtOTdmYi1jN2FhMzYzZjdkYzXYAgHgAgE&sid=f5bc3b3541918289922b34e594be1c20&all_sr_blocks=0_0_1_1_0&checkin=2026-01-13&checkout=2026-01-14&dest_id=1513&dest_type=region&dist=0&group_adults=1&group_children=0&hapos=1&highlighted_blocks=0_0_1_1_0&hpos=1&matching_block_id=0_0_1_1_0&no_rooms=1&req_adults=1&req_children=0&room1=A&sb_price_type=total&sr_order=popularity&sr_pri_blocks=0_0_1_1_0__13497&srepoch=1768293101&srpvid=67c43bc14ccd04bf&type=total&ucfs=1&",
                    Description = "Santorini este, fără îndoială, cea mai faimoasă insulă din arhipelagul Cicladelor, recunoscută mondial pentru clădirile sale alb-albastre cocoțate pe stânci vulcanice abrupte. Apusurile de soare din Oia sunt considerate printre cele mai frumoase din lume, oferind un spectacol de lumini calde care se reflectă în Marea Egee, creând o atmosferă de un romantism inegalabil.\n\n" +
                                  "Dincolo de peisajele de carte poștală, insula ascunde o istorie fascinantă legată de erupția minoică și situl arheologic Akrotiri. Plajele cu nisip negru sau roșu, podgoriile locale care produc vinuri vulcanice unice și tavernele tradiționale completează experiența. Este destinația perfectă pentru relaxare.",
                    Gallery = new List<DestinationImage>
                    {
                        new DestinationImage { Url = "/santorini1.jpg" },
                        new DestinationImage { Url = "/santorini2.jpg" },
                        new DestinationImage { Url = "/santorini3.jpg" },
                        new DestinationImage { Url = "/santorini4.jpg" },
                        new DestinationImage { Url = "/santorini5.jpg" },
                        new DestinationImage { Url = "/santorini6.jpg" }
                    },
                    Reviews = new List<Review>()
                },

                // 5. KYOTO (JAPONIA)
                new Destination
                {
                    Slug = "kyoto",
                    Title = "Kyoto, Japonia",
                    BannerImg = "/kyoto0.jpg", 
                    Price = 120,
                    HotelUrl = "https://www.booking.com/hotel/jp/rihga-royal-kyoto.ro.html?aid=304142&label=gen173nr-10CAso7AFCCHJvdXRlLTY2SDNYBGjAAYgBAZgBM7gBF8gBDNgBA-gBAfgBAYgCAagCAbgCh62FywbAAgHSAiQxNjZhYmI0Mi1iMjE4LTQwMmUtOTdmYi1jN2FhMzYzZjdkYzXYAgHgAgE&sid=f5bc3b3541918289922b34e594be1c20&all_sr_blocks=29807823_113396782_1_2_0&checkin=2026-01-13&checkout=2026-01-14&dest_id=-235402&dest_type=city&dist=0&group_adults=1&group_children=0&hapos=5&highlighted_blocks=29807823_113396782_1_2_0&hpos=5&matching_block_id=29807823_113396782_1_2_0&no_rooms=1&req_adults=1&req_children=0&room1=A&sb_price_type=total&sr_order=popularity&sr_pri_blocks=29807823_113396782_1_2_0__1368000&srepoch=1768293282&srpvid=c9c23c4603e70551&type=total&ucfs=1&",
                    Description = "Kyoto, fosta capitală imperială a Japoniei, este inima culturală și spirituală a țării. Orașul este un sanctuar al tradiției, găzduind mii de temple budiste, sanctuare șintoiste și grădini Zen meticoulos îngrijite. De la faimosul Pavilion de Aur (Kinkaku-ji) la porțile torii nesfârșite de la Fushimi Inari, Kyoto oferă o liniște și o frumusețe care îți taie respirația.\n\n" +
                                  "Cartierul Gion este locul unde poți zări încă gheishe veritabile îndreptându-se spre casele de ceai. Primăvara, orașul se transformă sub ploaia de petale a cireșilor înfloriți (Sakura), iar toamna frunzișul devine roșu aprins. Vizitatorii pot experimenta ceremonia ceaiului și bucătăria kaiseki rafinată.",
                    Gallery = new List<DestinationImage>
                    {
                        new DestinationImage { Url = "/kyoto1.jpg" },
                        new DestinationImage { Url = "/kyoto2.jpg" },
                        new DestinationImage { Url = "/kyoto3.jpg" },
                        new DestinationImage { Url = "/kyoto4.jpg" },
                        new DestinationImage { Url = "/kyoto5.jpg" },
                        new DestinationImage { Url = "/kyoto6.jpg" }
                    },
                    Reviews = new List<Review>()
                },

                // 6. REYKJAVIK (ISLANDA)
                new Destination
                {
                    Slug = "iceland",
                    Title = "Reykjavik, Islanda",
                    BannerImg = "/iceland0.jpg", 
                    Price = 170,
                    HotelUrl = "https://www.booking.com/hotel/is/icelandair-reykjavik-marina.ro.html?aid=304142&label=gen173nr-10CAso7AFCCHJvdXRlLTY2SDNYBGjAAYgBAZgBM7gBF8gBDNgBA-gBAfgBAYgCAagCAbgCh62FywbAAgHSAiQxNjZhYmI0Mi1iMjE4LTQwMmUtOTdmYi1jN2FhMzYzZjdkYzXYAgHgAgE&sid=f5bc3b3541918289922b34e594be1c20&all_sr_blocks=0_0_1_0_0&checkin=2026-01-13&checkout=2026-01-14&dest_id=-2651804&dest_type=city&dist=0&group_adults=1&group_children=0&hapos=8&highlighted_blocks=0_0_1_0_0&hpos=8&matching_block_id=0_0_1_0_0&no_rooms=1&req_adults=1&req_children=0&room1=A&sb_price_type=total&sr_order=popularity&sr_pri_blocks=0_0_1_0_0__13197&srepoch=1768293384&srpvid=28ee3c764f990344&type=total&ucfs=1&",
                    Description = "Islanda, tărâmul focului și al gheții, oferă prin capitala sa, Reykjavik, poarta de intrare către unele dintre cele mai spectaculoase fenomene naturale de pe Pământ. De aici, poți explora cascade masive, ghețari imenși, plaje cu nisip negru și geysere active. Este un loc unde natura dictează ritmul vieții, iar peisajele par desprinse de pe altă planetă.\n\n" +
                                  "Iarna, cerul nopții dansează sub culorile aurorei boreale, un spectacol hipnotizant pentru orice privitor. Vara, soarele de la miezul nopții îți permite să explorezi natura 24 de ore din 24. După o zi de aventură, te poți relaxa în apele geotermale ale Lagunei Albastre.",
                    Gallery = new List<DestinationImage>
                    {
                        new DestinationImage { Url = "/iceland1.jpg" },
                        new DestinationImage { Url = "/iceland2.jpg" },
                        new DestinationImage { Url = "/iceland3.jpg" },
                        new DestinationImage { Url = "/iceland4.jpg" },
                        new DestinationImage { Url = "/iceland5.jpg" },
                        new DestinationImage { Url = "/iceland6.jpg" }
                    },
                    Reviews = new List<Review>()
                },

                // 7. MACHU PICCHU (PERU)
                new Destination
                {
                    Slug = "machu-picchu",
                    Title = "Machu Picchu, Peru",
                    BannerImg = "/peru0.jpg", 
                    Price = 140,
                    HotelUrl = "https://www.booking.com/hotel/pe/taypikala-machupicchu.ro.html?aid=304142&label=gen173nr-10CAso7AFCCHJvdXRlLTY2SDNYBGjAAYgBAZgBM7gBF8gBDNgBA-gBAfgBAYgCAagCAbgCh62FywbAAgHSAiQxNjZhYmI0Mi1iMjE4LTQwMmUtOTdmYi1jN2FhMzYzZjdkYzXYAgHgAgE&sid=f5bc3b3541918289922b34e594be1c20&all_sr_blocks=32934202_106848572_0_1_0&checkin=2026-01-13&checkout=2026-01-14&dest_id=-353770&dest_type=city&dist=0&group_adults=1&group_children=0&hapos=1&highlighted_blocks=32934202_106848572_0_1_0&hpos=1&matching_block_id=32934202_106848572_0_1_0&no_rooms=1&req_adults=1&req_children=0&room1=A&sb_price_type=total&sr_order=popularity&sr_pri_blocks=32934202_106848572_0_1_0__11248&srepoch=1768293477&srpvid=5af33c99a9fa00b3&type=total&ucfs=1&",
                    Description = "Ascuns între vârfurile abrupte ale Anzilor, Machu Picchu este una dintre cele mai enigmatice și impresionante așezări antice din lume. Orașul pierdut al incașilor a rămas nedescoperit de spanioli și a fost dezvăluit lumii moderne abia în 1911. Terasele agricole, templele de piatră și priveliștile amețitoare fac din acest loc o minune arhitecturală și spirituală.\n\n" +
                                  "Accesul se poate face fie prin celebrul Inca Trail, o drumeție de câteva zile prin munți, fie cu trenul panoramic până la baza muntelui. Răsăritul soarelui peste ruine, cu ceața ridicându-se din valea râului Urubamba, este un moment mistic pe care niciun vizitator nu îl uită vreodată.",
                    Gallery = new List<DestinationImage>
                    {
                        new DestinationImage { Url = "/peru1.jpg" },
                        new DestinationImage { Url = "/peru2.jpg" },
                        new DestinationImage { Url = "/peru3.jpg" },
                        new DestinationImage { Url = "/peru4.jpg" },
                        new DestinationImage { Url = "/peru5.jpg" },
                        new DestinationImage { Url = "/peru6.jpg" }
                    },
                    Reviews = new List<Review>()
                },

                // 8. BORA BORA (POLINEZIA FRANCEZA)
                new Destination
                {
                    Slug = "bora-bora",
                    Title = "Bora Bora, Polinezia",
                    BannerImg = "/bora0.jpg", 
                    Price = 260,
                    HotelUrl = "https://www.booking.com/hotel/pf/oa-oa-lodge.ro.html?aid=304142&label=gen173nr-10CAso7AFCCHJvdXRlLTY2SDNYBGjAAYgBAZgBM7gBF8gBDNgBA-gBAfgBAYgCAagCAbgCh62FywbAAgHSAiQxNjZhYmI0Mi1iMjE4LTQwMmUtOTdmYi1jN2FhMzYzZjdkYzXYAgHgAgE&sid=f5bc3b3541918289922b34e594be1c20&all_sr_blocks=167500703_366515344_3_0_0&checkin=2026-01-13&checkout=2026-01-14&dest_id=3978&dest_type=region&dist=0&group_adults=1&group_children=0&hapos=7&highlighted_blocks=167500703_366515344_3_0_0&hpos=7&matching_block_id=167500703_366515344_3_0_0&no_rooms=1&req_adults=1&req_children=0&room1=A&sb_price_type=total&sr_order=popularity&sr_pri_blocks=167500703_366515344_3_0_0__2628725&srepoch=1768293600&srpvid=2c453cd5246a03d9&type=total&ucfs=1&",
                    Description = "Bora Bora este definiția paradisului tropical, o insulă vulcanică înconjurată de una dintre cele mai frumoase lagune din lume. Dominată de vârful impunător al muntelui Otemanu, insula este celebră pentru bungalow-urile suspendate deasupra apei turcoaz, unde poți sări direct din dormitor în ocean. Este destinația supremă pentru lux și intimitate.\n\n" +
                                  "Viața marină este spectaculoasă, oferind ocazia de a înota alături de pisici de mare și rechini de recif inofensivi. Fie că te relaxezi pe plajele cu nisip alb fin, explorezi insula cu un 4x4 sau te bucuri de un picnic pe un 'motu' (insuliță) pustiu, Bora Bora promite o evadare totală din cotidian.",
                    Gallery = new List<DestinationImage>
                    {
                        new DestinationImage { Url = "/bora1.jpg" },
                        new DestinationImage { Url = "/bora2.jpg" },
                        new DestinationImage { Url = "/bora3.jpg" },
                        new DestinationImage { Url = "/bora4.jpg" },
                        new DestinationImage { Url = "/bora5.jpg" },
                        new DestinationImage { Url = "/bora6.jpg" },
                    },
                    Reviews = new List<Review>()
                },

                // 9. PETRA (IORDANIA)
                new Destination
                {
                    Slug = "petra",
                    Title = "Petra, Iordania",
                    BannerImg = "/petra0.jpg", 
                    Price = 190,
                    HotelUrl = "https://www.booking.com/hotel/jo/moevenpick-resort-petra.ro.html?aid=304142&label=gen173nr-10CAso7AFCCHJvdXRlLTY2SDNYBGjAAYgBAZgBM7gBF8gBDNgBA-gBAfgBAYgCAagCAbgCh62FywbAAgHSAiQxNjZhYmI0Mi1iMjE4LTQwMmUtOTdmYi1jN2FhMzYzZjdkYzXYAgHgAgE&sid=f5bc3b3541918289922b34e594be1c20&all_sr_blocks=2329214_95147340_1_41_0&checkin=2026-01-13&checkout=2026-01-14&dest_id=3470&dest_type=region&dist=0&group_adults=1&group_children=0&hapos=2&highlighted_blocks=2329214_95147340_1_41_0&hpos=2&matching_block_id=2329214_95147340_1_41_0&nad_cpc=0.5&nad_id=bf8b2df7-c1ff-4412-8f18-8a2c110ffc78_0&nad_placement=SR_MAIN&nad_track=eyJhdWN0aW9uRXBvY2giOjE3NjgyOTM2NjI3NTgsInJhbmsiOjEsImtvZGRpVHJhY2tpbmdJbmZvIjoiRzR6UC8xNjN5VEtSb1NDb0QwSUo1VlRyWEdxTWJGLzBpczZVS01lRDhaZUFkOHVSMVU3QkhvRUNIUGtkRHQyemN4dVF4QXNLb0dzR1RCTEVodUFiTEFpYXZSdGJJQ1E2emJOK2ZYbVNtZkE1QzlWU2RkaDlFbUV1OHowSzlZZWlybTRQNWF6N1FhRytzQ1BwT0pVd09ublBDVVpyQjh0OFczZFY4c1dIMzloUWk3S2tTbTcyUXNuam5RaHVIc25nUmk0dmRjYlhMMXU3YTBHd2dwZDl3SC8wbjdnenlrazUrYjJmelZtWEd4emlDdTBqd1FXN3JneFhIcGp4aUN6QWEvazZnUXN3UDFWb3BGdGdMMStRSDR6VDRXQ216V3JjNERzOTV2SVFJQUxxODZIM0E2TjhVL1EraW15Nm1ocnhjaVRPQmhZbExpVzF5NDk4aGN3OG04OG0wSEFBT0lEL3BjNUlXTWZFRms2bG5Ob1FJN0ZHZ1F2L3RHYml5ejhEbFR6dEx6MGFiTURxWGZIMDFYMkJlVlhpQmVpVlhKYWVlSEVuWkRWeWtWS3NPUEdhQ1A3TGNSOE5BOWFhQUJsL29QUm01aUVmSXQzNTgyZTB2ZWhiM2R4anhGK1NxdGw0M0lBWEpkMEtxeXhVZEZJNExGLzZqcjJMaFd0Z1QzSUgyYzB2dGg4bHNoTzlSWHFQYTFTY1JSbU80eGFmSjVsanVRVkF0RDkydXlBVE5Wcloxd3pBT0ZCZXU3RllId1hIeVV5dUlzcHJXNmdTSVFaRmNFT25BeVZCb0hXd2RSMHdDV3hyMnZEd1RFcUFSeks0YVQ3dkNGM1NoZGhwYndnL2luSGFOZ0xUQ2NVamppWkRRUHcwbWdUWWkwMHo0dTUvVXRSOURsVjVMOFFnWUlQZkt3Wk5mbFUzVjlRWUNmT2JFY0V6MFdocHhzQUhOR2VSaS9mQU9oMitQRzRhZGlaZzlya2pQdlNRRWxZM0JWTG00RTBBYUpKdFRvN1hidS9NTlBSYUVpZkR1SDdVS3JvclJvN1o1QXZJZWloNTdiQlFOYnc3aTZwd0RXRmh3d1d4Z3hiTWY5V1VaUWJOYTVrVmcyQmlONHRzaGNUTDZvVDk3VEI5M0hoM0lpUktoQlpDR0NSdkxYQU5uay9TNUJKUUpZeVl1Nk43dVBwS0xOeit3TDRTSGFHd29jRytad0ZTMEJSb3lDd3lsOThzTTJ5WGw1NHlIZ1daUzRwOWdYb2F6RlR5K2RkQmV6U1RnNTRSSjYxdEplZU5EWDZkSzkrTjZ4SmNEbTBCU0JqUFhjMDFhNjUzWmlpVzZkVlQ1amVmUnR3RE1KNVZNTlNHKzNFWXkwU0svZ3RoQW1ramFtSTNhTU83LzRpNVRaZFhzc0hsYmVMVndSU0VoS2MwTEpsSlBoTTI3ek5WdWEzcW5BNGZFam11cy9PaFRSSkFZbDJXK3B4bzlJc1VIK1kzOW56OElBZUREdVVpSFBWYTdOUUU1Ym1aSkY4Unc1RXVkaGNYV2tmRzhRaGtMeHN1dEdMWjBhRWwrRmlkVGxHeTVyMVdzODZUbGNxS3h1TzBaUnVVSmNVWjVvRlRmdzlaUVI2TTFiZ0NHSEQvbkt3R1hKZlBrUGpsSmZGU3A2Q2J1cTc4NVdGaFRQSUZUUUN6aWZDeGlZRkFzQnViMmNxOVdZK3NpazBFNUdnM0t0amthaFludGRCT1owd2pOdDVGSnJqTW8xUGRITVRaQUtaaWp0cEpDSU05dFkzdjJGMU80dWtSaGxPbXhVcWZ1OXYvSElhQ0N5WU02Mk9zVm05OWhLaWhrK054ODlUd2FwWGtBNklVN1Z1SmY2RjdXMmRNbWVHSUlTL2V6bVlLVklRRTU3YncrUmhRYWlSUWlSYjc3YnNtKzhxL0hXMWNYOTB4bHA2NGV0dU9aMTZrN3pFUEowNzl0RHU3Qlc4WXJYRkJkNHZObDdEQytBUT0ifQ%3D%3D&no_rooms=1&req_adults=1&req_children=0&room1=A&sb_price_type=total&sr_order=popularity&sr_pri_blocks=2329214_95147340_1_41_0__12136&srepoch=1768294654&srpvid=ab303d0ebb8602fe&type=total&ucfs=1&",
                    Description = "Cunoscută drept 'Orașul Trandafiriu' datorită culorii pietrei în care a fost săpată, Petra este comoara Iordaniei și una dintre noile minuni ale lumii. Intrarea în oraș se face prin Siq, un canion îngust și spectaculos, care se deschide brusc pentru a dezvălui Trezoreria (Al-Khazneh), o fațadă monumentală sculptată direct în stâncă acum peste 2000 de ani.\n\n" +
                                  "Acest oraș antic al nabateenilor este vast, cuprinzând morminte regale, un teatru roman și mănăstiri cocoțate pe vârfuri de munte. O vizită la Petra nu este doar o lecție de istorie, ci și o aventură, având ocazia să interacționezi cu beduinii locali și să experimentezi ospitalitatea deșertului sub un cer plin de stele.",
                    Gallery = new List<DestinationImage>
                    {
                        new DestinationImage { Url = "/petra1.jpg" },
                        new DestinationImage { Url = "/petra2.jpg" },
                        new DestinationImage { Url = "/petra3.jpg" },
                        new DestinationImage { Url = "/petra4.jpg" },
                        new DestinationImage { Url = "/petra5.jpg" },
                        new DestinationImage { Url = "/petra6.jpg" }
                    },
                    Reviews = new List<Review>()
                },

                // 10. LAOS (LUANG PRABANG)
                new Destination
                {
                    Slug = "laos",
                    Title = "Luang Prabang, Laos",
                    BannerImg = "/laos0.jpg", 
                    Price = 130,
                    HotelUrl = "https://www.booking.com/hotel/la/vang-luang.ro.html?aid=304142&label=gen173nr-10CAso7AFCCHJvdXRlLTY2SDNYBGjAAYgBAZgBM7gBF8gBDNgBA-gBAfgBAYgCAagCAbgCh62FywbAAgHSAiQxNjZhYmI0Mi1iMjE4LTQwMmUtOTdmYi1jN2FhMzYzZjdkYzXYAgHgAgE&sid=f5bc3b3541918289922b34e594be1c20&all_sr_blocks=1346913901_407046841_2_1_0&checkin=2026-01-13&checkout=2026-01-14&dest_id=-2665957&dest_type=city&dist=0&group_adults=1&group_children=0&hapos=3&highlighted_blocks=1346913901_407046841_2_1_0&hpos=3&matching_block_id=1346913901_407046841_2_1_0&no_rooms=1&req_adults=1&req_children=0&room1=A&sb_price_type=total&sr_order=popularity&sr_pri_blocks=1346913901_407046841_2_1_0__9866&srepoch=1768294727&srpvid=1f8e3f15de810270&type=total&ucfs=1&",
                    Description = "Luang Prabang, fosta capitală regală a Laosului, este un loc unde timpul pare să se fi oprit în loc, învăluit într-o liniște spirituală profundă. Situat la confluența fluviilor Mekong și Nam Khan, orașul este faimos pentru ritualul zilnic de dimineață (Tak Bat), când sute de călugări în robe portocalii merg desculți pe străzi pentru a primi ofrande de orez de la localnici. Templele aurite, precum Wat Xieng Thong, strălucesc în soarele tropical, oferind un decor de meditație perfect.\n\n" +
                                  "Dincolo de spiritualitate, natura din jurul orașului este spectaculoasă. Cascada Kuang Si, cu bazinele sale naturale de un turcoaz ireal, este locul ideal pentru o baie răcoritoare în junglă. Seara, piața de noapte animă centrul vechi cu felinare colorate și produse artizanale, totul desfășurându-se într-o atmosferă calmă, specifică stilului de viață relaxat al laotienilor.",
                    Gallery = new List<DestinationImage>
                    {
                        new DestinationImage { Url = "/laos1.jpg" },
                        new DestinationImage { Url = "/laos2.jpg" },
                        new DestinationImage { Url = "/laos3.jpg" },
                        new DestinationImage { Url = "/laos4.jpg" },
                        new DestinationImage { Url = "/laos5.jpg" },
                        new DestinationImage { Url = "/laos6.jpg" }
                    },
                    Reviews = new List<Review>()
                },

                // 11. JAIPUR (INDIA)
                new Destination
                {
                    Slug = "jaipur",
                    Title = "Jaipur, India",
                    BannerImg = "/jaipur0.jpg", 
                    Price = 100,
                    HotelUrl = "https://www.booking.com/hotel/in/country-inn-suites-by-carlson-jaipur.ro.html?aid=304142&label=gen173nr-10CAso7AFCCHJvdXRlLTY2SDNYBGjAAYgBAZgBM7gBF8gBDNgBA-gBAfgBAYgCAagCAbgCh62FywbAAgHSAiQxNjZhYmI0Mi1iMjE4LTQwMmUtOTdmYi1jN2FhMzYzZjdkYzXYAgHgAgE&sid=f5bc3b3541918289922b34e594be1c20&all_sr_blocks=24382231_94362463_1_42_0&checkin=2026-01-13&checkout=2026-01-14&dest_id=-2098033&dest_type=city&dist=0&group_adults=1&group_children=0&hapos=2&highlighted_blocks=24382231_94362463_1_42_0&hpos=2&matching_block_id=24382231_94362463_1_42_0&no_rooms=1&req_adults=1&req_children=0&room1=A&sb_price_type=total&sr_order=popularity&sr_pri_blocks=24382231_94362463_1_42_0__765450&srepoch=1768294788&srpvid=bd913f3fbc090659&type=total&ucfs=1&",
                    Description = "Jaipur, supranumit 'Orașul Roz' datorită culorii clădirilor sale istorice, este o explozie de haos, culoare și regalitate în inima deșertului Rajasthan. Simbolul orașului, Hawa Mahal (Palatul Vânturilor), cu fațada sa dantelată cu 953 de ferestre mici, a fost construit pentru ca doamnele de la curte să poată privi viața străzii fără a fi văzute. Străzile sunt un amestec vibrant de cămile, ricșe, bazaruri de bijuterii și palate fastuoase.\n\n" +
                                  "O vizită la Fortul Amber, cocoțat pe un deal stâncos la marginea orașului, te transpune în vremea maharajahilor, oferind curți interioare decorate cu oglinzi și grădini suspendate. Jaipur este, de asemenea, un paradis pentru cumpărături, fiind renumit mondial pentru pietre prețioase, textile imprimate manual și ceramică albastră, oferind o experiență senzorială intensă și autentic indiană.",
                    Gallery = new List<DestinationImage>
                    {
                        new DestinationImage { Url = "/jaipur1.jpg" },
                        new DestinationImage { Url = "/jaipur2.jpg" },
                        new DestinationImage { Url = "/jaipur3.jpg" },
                        new DestinationImage { Url = "/jaipur4.jpg" },
                        new DestinationImage { Url = "/jaipur5.jpg" },
                        new DestinationImage { Url = "/jaipur6.jpg" }
                    },
                    Reviews = new List<Review>()
                }

            };

            context.Destinations.AddRange(destinations);
            context.SaveChanges();
        }
    }
}