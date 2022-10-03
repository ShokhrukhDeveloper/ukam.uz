import 'package:flutter/material.dart';
import 'package:referat/app_colors/app_text_styles.dart';

class ProfileBooksWidget {
  static profileBooksWidget(BuildContext context, TabController? controller) {
    return SizedBox(
      height: MediaQuery.of(context).size.height * 0.65,
      width: MediaQuery.of(context).size.width * 0.65,
      child: Column(
        mainAxisAlignment: MainAxisAlignment.start,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          SizedBox(
            width: MediaQuery.of(context).size.width,
            height: 105,
            child: Padding(
              padding: const EdgeInsets.all(30),
              child: Row(
                children: [
                  const Text(
                    'Китобларим',
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 30),
                  ),
                  const SizedBox(width: 80),
                  SizedBox(
                    height: 40,
                    width: 450,
                    child: TabBar(
                      controller: controller,
                      tabs: const [
                        Tab(
                            child: Text(
                          'Аудиокитоб',
                          style: TextStyle(color: Color(0xff3F51B5)),
                        )),
                        Tab(
                            height: 40,
                            child: Text(
                              'Электрон китоб',
                              style: TextStyle(
                                color: Color(0xff3F51B5),
                              ),
                            )),
                        Tab(
                            height: 40,
                            child: Text(
                              'Босма китоб',
                              style: TextStyle(
                                color: Color(0xff3F51B5),
                              ),
                            )),
                      ],
                    ),
                  ),
                ],
              ),
            ),
          ),
          SizedBox(
            height: 354,
            width: 974,
            child: TabBarView(
              controller: controller,
              children: [
                _productWidget(context),
                _productWidget(context),
                _productWidget(context),
              ],
            ),
          ),
        ],
      ),
    );
  }

  static Container _productWidget(BuildContext context) {
    return Container(
      decoration: BoxDecoration(borderRadius: BorderRadius.circular(14)),
      height: 100,
      width: 100,
      child: Row(
        children: [
          Container(
            decoration: BoxDecoration(
              borderRadius: BorderRadius.circular(14),
              image: const DecorationImage(
                image: NetworkImage('https://source.unsplash.com/random'),
                fit: BoxFit.cover,
              ),
            ),
            height: MediaQuery.of(context).size.height,
            width: 280,
          ),
          Padding(
            padding: const EdgeInsets.all(15.0),
            child: Column(
              mainAxisAlignment: MainAxisAlignment.spaceEvenly,
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    const Text(
                      "Элжернга аталган гуллар",
                      style: TextStyle(
                        fontSize: 30,
                        fontWeight: FontWeight.bold,
                      ),
                    ),
                    const SizedBox(width: 50),
                    Row(
                      mainAxisSize: MainAxisSize.min,
                      children: const [
                        Icon(Icons.star, size: 20, color: Color(0xffFF754C)),
                        SizedBox(width: 5),
                        Text(
                          "4.7",
                          style: AppTextStyles.text28W700Style,
                        ),
                        SizedBox(width: 5),
                        Text('244 фиклар',
                            style: TextStyle(color: Colors.grey, fontSize: 14)),
                      ],
                    ),
                  ],
                ),
                const Text(
                  "SIYOSAT, FANTASTIKA",
                  style: TextStyle(
                    color: Color(0xff3F51B5),
                  ),
                ),
                const Text(
                  'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore\n et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut\n aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse\n cillum dolore eu fugiat nulla pariatur. ',
                  maxLines: 4,
                ),
                Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    SizedBox(
                      child: Row(
                        children: [
                          Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: const [
                              Text(
                                'Муаллиф',
                                style: TextStyle(
                                  color: Color(0xffAAAAAA),
                                ),
                              ),
                              SizedBox(height: 10),
                              Text(
                                'Kevin Smiley',
                                style: TextStyle(fontSize: 18),
                              ),
                            ],
                          ),
                          const SizedBox(width: 70),
                          Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: const [
                              Text(
                                'Нашриёт',
                                style: TextStyle(
                                  color: Color(0xffAAAAAA),
                                ),
                              ),
                              SizedBox(height: 10),
                              Text(
                                'Printarea Studios',
                                style: TextStyle(fontSize: 18),
                              ),
                            ],
                          ),
                          const SizedBox(width: 70),
                          Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: const [
                              Text(
                                'Йил',
                                style: TextStyle(
                                  color: Color(0xffAAAAAA),
                                ),
                              ),
                              SizedBox(height: 10),
                              Text(
                                '2019',
                                style: TextStyle(fontSize: 18),
                              ),
                            ],
                          ),
                        ],
                      ),
                    ),
                    Row(
                      children: const [
                        Icon(Icons.headphones),
                        SizedBox(width: 20),
                        Icon(Icons.bookmark_border_sharp),
                      ],
                    ),
                  ],
                ),
              ],
            ),
          ),
        ],
      ),
    );
  }
}
