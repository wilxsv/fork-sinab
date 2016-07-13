using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;

namespace SINAB_Utils
{
   

    public static class Semana
    {
        public static Dictionary<int, string> ObtenerTodasHastaHoy()
        {
           /* //primero de enero
            var enero = new DateTime(DateTime.Today.Year, 1, 1);
            //punto de partida
            var puntoPartida = enero.AddDays(1 - (int)(enero.DayOfWeek));

            var semanas = Enumerable.Range(0, 54) //semanas en el año
                .Select(i => new { semanaInicio = puntoPartida.AddDays(i * 7) }) //armamos la semana
                .TakeWhile(x => x.semanaInicio <= DateTime.Today) //mientras la semana sea menor o igual a la actual
                .Select(s => new { s.semanaInicio, semanaFin = s.semanaInicio.AddDays(6) }) //armamos los dias por semana
                .SkipWhile(x => x.semanaFin < enero.AddDays(1))
                //mientras la semana que finaliza sea menor que 1ro de enero (del proximo año?)
                .Select(
                    (x, i) =>
                        new
                        {
                            RangoSemana = string.Format(
                                "Semana {0}, del {1} de {2} al {3} de {4}",
                                (i + 1),
                                x.semanaInicio.Day,
                                CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x.semanaInicio.Month),
                                x.semanaFin.Day,
                                CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x.semanaFin.Month)),
                            NumeroSemana = i + 1
                        }) //el rango de las semanas
                .ToDictionary(ob => ob.NumeroSemana, ob => ob.RangoSemana);
            return semanas;*/

            var year = DateTime.Now.Year;
            var weeks = new List<Infosemana>();
            var startDate = new DateTime(year, 1, 1);
            startDate = startDate.AddDays(1 - (int)startDate.DayOfWeek);
            if (startDate.Year < year)
            {
                startDate = startDate.AddDays(7);
            }
            var endDate = startDate.AddDays(6);
            var count = 1;
            while (startDate.Year < 1 + year)
            {
                weeks.Add(new Infosemana()
                {
                    Semana = count,
                    Informacion = string.Format("Semana {0}: Del {1} de {2} al {3} de {4}", count,
                    startDate.Day, CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(startDate.Month),
                    endDate.Day, CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(endDate.Month)),
                    FechaInicio = startDate,
                    FechaFin = endDate

                });

                startDate = startDate.AddDays(7);
                endDate = endDate.AddDays(7);
                count++;
            }
            return weeks.TakeWhile(w => w.FechaInicio <= DateTime.Now).ToDictionary(w => w.Semana, w => w.Informacion); 
           
        }

        public static Dictionary<int, string> ObtenerTodasAnteriores(int anio)
        {
            /*//primero de enero
            var enero = new DateTime(anio, 1, 1);
            //punto de partida
            var puntoPartida = enero.AddDays(1 - (int)(enero.DayOfWeek));

            var semanas = Enumerable.Range(0, 54) //semanas en el año
                .Select(i => new { semanaInicio = puntoPartida.AddDays(i * 7) }) //armamos la semana
                .TakeWhile(x => x.semanaInicio.Year <= enero.Year) //mientras el año sea menor o igual al actual
                .Select(s => new { s.semanaInicio, semanaFin = s.semanaInicio.AddDays(6) }) //armamos los dias por semana
                .SkipWhile(x => x.semanaFin < enero.AddDays(1))
                //mientras la semana que finaliza sea menor que 1ro de enero (del proximo año?)
                .Select(
                    (x, i) =>
                        new
                        {
                            RangoSemana = string.Format(
                                "Semana {0}, del {1} de {2} al {3} de {4}",
                                (i + 1),
                                x.semanaInicio.Day,
                                CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x.semanaInicio.Month),
                                x.semanaFin.Day,
                                CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(x.semanaFin.Month)),
                            NumeroSemana = i + 1
                        }) //el rango de las semanas
                .ToDictionary(ob => ob.NumeroSemana, ob => ob.RangoSemana);
            return semanas;*/

            var year = anio;
            var weeks =  new List<Infosemana>();
            var startDate = new DateTime(year, 1, 1);
            startDate = startDate.AddDays(1 - (int)startDate.DayOfWeek);
            var endDate = startDate.AddDays(6);
            var count = 1;
            while (startDate.Year < 1 + year)
            {
                weeks.Add(new Infosemana()
                {
                    Semana = count,
                    Informacion = string.Format("Semana {0}: Del {1} de {2} al {3} de {4}", count,
                    startDate.Day, CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(startDate.Month),
                    endDate.Day, CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(endDate.Month)),
                    FechaInicio =startDate,
                    FechaFin =endDate
                    
                });
                
                startDate = startDate.AddDays(7);
                endDate = endDate.AddDays(7);
                count++;
            }
            return weeks.TakeWhile(w => w.FechaInicio.Year <= DateTime.Now.Year).ToDictionary(w => w.Semana, w => w.Informacion); 
        }

        public static int ObtenerNumero()
        {
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
        }

        public static string ObtenerInformacion(int year, int week)
        {
            var primerdia = FechaInicio(year, week);
            var day = primerdia.Day;
            return string.Format("Semana {0}, del {1} de {2} al {3} de {4}", week, day,
                CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(primerdia.Month)
                , primerdia.AddDays(6).Day,
                CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(primerdia.AddDays(6).Month));
        }


        public static DateTime FechaInicio(int year, int semana)
        {
            var ci = System.Threading.Thread.CurrentThread.CurrentCulture;
            var enero1 = new DateTime(year, 1, 1);
            var daysOffset = (int)ci.DateTimeFormat.FirstDayOfWeek - (int)enero1.DayOfWeek;
            var firstWeekDay = enero1.AddDays(daysOffset);
            //var firstWeek = ci.Calendar.GetWeekOfYear(enero1, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
            //if (/*firstWeek <= 1 ||*/ firstWeek > 50)
            //{
            //    semana -= 1;
            //}
            return firstWeekDay.AddDays(semana * 7);
        }
    }
}
