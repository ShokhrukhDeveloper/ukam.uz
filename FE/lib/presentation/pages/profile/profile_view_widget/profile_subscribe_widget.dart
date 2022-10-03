import 'package:flutter/material.dart';

var itemsDays = [
  "30 кун",
  "180 кун",
  "365 кун",
];
var itemsCategory = [
  'Жахон адабиёти',
  'Узбек адабиёти',
  'Бизнес ва психология',
  'Болалар адабиёти',
  'Детективлар',
  'Фантастика',
  'Диний адабиёт',
  'Фан ва таьлим',
  'Куннинг енг яхшилари',
];
String dropdownInitialDays = "30 кун";
String dropDownInitialCategory = 'Жахон адабиёти';
var selectIndex = 0;

class ProfileSubscribeWidget {
  static profileSubscribeWidget(BuildContext context) {
    return SizedBox(
      height: MediaQuery.of(context).size.height * 0.65,
      width: MediaQuery.of(context).size.width * 0.65,
      child: profileSubscribeWidget(context),
    );
  }
}

SizedBox profileSubscribeWidget(BuildContext context) {
  return SizedBox(
    child: Column(
      mainAxisAlignment: MainAxisAlignment.start,
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Row(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                const Text('Обуна',
                    style:
                        TextStyle(fontSize: 30, fontWeight: FontWeight.bold)),
                const Padding(
                    padding: EdgeInsets.only(top: 16, bottom: 6),
                    child: Text('Обуна давом этиш вакти')),
                //? Dorp Down Button (vaqti)
                dropDownButtonDays(context),
                //? Text (Bolimni tanlash)
                const Padding(
                    padding: EdgeInsets.only(top: 16, bottom: 6),
                    child: Text('Булимни танланг')),
                //? Dorp Down Button (bolimni tanlash)
                dropDownButtonCategory(context),
                //? Text (obuna 30 kun ...)
                const Padding(
                  padding: EdgeInsets.only(top: 36),
                  child: Text(
                    'Обуна 30 кун давом этади',
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 20),
                  ),
                ),
              ],
            ),
            Column(
              children: [
                Container(
                  height: 140,
                  width: 368,
                  color: const Color(0xfff5f5f5),
                  child: Padding(
                    padding: const EdgeInsets.all(8.0),
                    child: Column(
                      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                      children: [
                        _textsss('Бошланиш вакти', "12/10/2021", Colors.black),
                        _textsss('Якунланиш вакти', "12/10/2021", Colors.black),
                        //? Text (obuna narxi ,price)
                        _textsss('Обуна нархи', "12 000 сум", Colors.black),
                      ],
                    ),
                  ),
                ),
                const SizedBox(height: 30),
                elevatedButton(
                  context,
                  () {},
                  'Обуна булиш',
                  Colors.green,
                  368,
                  h: 44,
                ),
              ],
            ),
          ],
        ),
      ],
    ),
  );
}

SizedBox dropDownButtonDays(BuildContext context) {
  return SizedBox(
    height: 50,
    width: 343,
    child: DropdownButtonFormField(
      decoration: InputDecoration(
        border: OutlineInputBorder(
          borderRadius: BorderRadius.circular(16),
        ),
      ),
      value: dropdownInitialDays,
      items: itemsDays.map((String items) {
        return DropdownMenuItem(
          value: items,
          child: Text(items),
        );
      }).toList(),
      onChanged: (String? newValue) {
        dropdownInitialDays = newValue!;
      },
    ),
  );
}

SizedBox dropDownButtonCategory(BuildContext context) {
  return SizedBox(
    height: 50,
    width: 343,
    child: DropdownButtonFormField(
      decoration: InputDecoration(
        border: OutlineInputBorder(
          borderRadius: BorderRadius.circular(16),
        ),
      ),
      value: dropDownInitialCategory,
      items: itemsCategory.map((String items) {
        return DropdownMenuItem(
          value: items,
          child: Text(items),
        );
      }).toList(),
      onChanged: (String? newValue) {
        dropDownInitialCategory = newValue!;
      },
    ),
  );
}

ElevatedButton elevatedButton(
    BuildContext context, onPressed, text, Color color, double w,
    {double h = 56}) {
  return ElevatedButton(
    style: ElevatedButton.styleFrom(
        shape: RoundedRectangleBorder(
          borderRadius: BorderRadius.circular(24),
        ),
        primary: color,
        fixedSize: Size(w, h)),
    onPressed: onPressed,
    child: Text(
      text,
      style: const TextStyle(fontSize: 16, color: Colors.white),
    ),
  );
}

Padding _textsss(txt1, txt2, color) {
  return Padding(
    padding: EdgeInsets.symmetric(vertical: 12),
    child: Row(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        Text(
          "$txt1",
        ),
        Text(
          "$txt2",
        ),
      ],
    ),
  );
}
