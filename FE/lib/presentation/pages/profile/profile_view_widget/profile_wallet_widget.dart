import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';

class ProfileWalletWidget {
  static profileWalletWidget(BuildContext context) {
    return SizedBox(
      height: MediaQuery.of(context).size.height * 0.65,
      width: MediaQuery.of(context).size.width * 0.65,
      child: Column(
        children: [
          Container(
            height: 100,
            width: MediaQuery.of(context).size.width,
            decoration: BoxDecoration(
              borderRadius: BorderRadius.circular(20),
              color: Colors.green,
            ),
            //? Widgets in Cart (Text,Svg)
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                //? Text Balans
                Padding(
                  padding: const EdgeInsets.only(left: 25, top: 20),
                  child: Column(
                    mainAxisAlignment: MainAxisAlignment.start,
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: const [
                      Text('Баланс', style: TextStyle(color: Colors.white)),
                      SizedBox(height: 10),
                      Text(
                        "45 000 сўм",
                        style: TextStyle(
                          color: Colors.white,
                          fontSize: 24,
                          fontWeight: FontWeight.bold,
                        ),
                      ),
                    ],
                  ),
                ),
                Column(mainAxisAlignment: MainAxisAlignment.end, children: [
                  SizedBox(
                    child: SvgPicture.asset("assets/svgs/pay_icon.svg"),
                  )
                ])
              ],
            ),
          ),
          const SizedBox(height: 20),
          // buttons_pay(context, 'click'),
          // buttons_pay(context, 'payme'),
        ],
      ),
    );
  }
}

InkWell buttons_pay(BuildContext context, asset) {
  return InkWell(
    onTap: () => Navigator.pushNamed(context, "/profile_fill_balance"),
    child: Container(
      width: MediaQuery.of(context).size.width,
      height: 61,
      decoration: BoxDecoration(
        borderRadius: BorderRadius.circular(20),
        border: Border.all(color: Colors.green),
      ),
      child: Center(child: Image.asset("assets/svgs/$asset.svg")),
    ),
  );
}
