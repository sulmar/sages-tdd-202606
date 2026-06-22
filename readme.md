# Testing Course

Kurs prowadzi od podstaw pisania testów jednostkowych, przez testy integracyjne i funkcjonalne, aż po refaktoryzację wspieraną testami.

## Ścieżka kursu

```
Jak napisać test?
        ↓
Jak znaleźć przypadki testowe?
        ↓
Jak budować kod metodą TDD?
        ↓
Jak rozpoznać kod trudny do testowania?
        ↓
Jak zastępować zależności w testach?
        ↓
Jak refaktoryzować kod pod osłoną testów?
        ↓
Jak testować współpracę komponentów?
        ↓
Jak testować proces biznesowy?
```

| Moduł | Pytanie |
|-------|---------|
| 01_Fundamentals | Jak napisać test? |
| 02_TestDesign | Jak znaleźć przypadki testowe? |
| 03_TDD | Jak budować kod metodą TDD? |
| 04_Testability | Jak rozpoznać kod trudny do testowania? |
| 05_TestDoubles | Jak zastępować zależności w testach? |
| 06_RefactoringWithTests | Jak refaktoryzować kod pod osłoną testów? |
| 07_IntegrationTesting | Jak testować współpracę komponentów? |
| 08_FunctionalTesting | Jak testować proces biznesowy? |

## Poziomy testów

```
Unit Test
        ↓ testuje metodę
Integration Test
        ↓ testuje współpracę komponentów
End-to-End Test
        ↓ testuje proces biznesowy
```

| Poziom | Moduły | Przykład |
|--------|--------|----------|
| Unit Test | 01–06 | test metody `CalculateDiscount` |
| Integration Test | 07 | repozytorium + SQLite, API HTTP, Redis |
| End-to-End Test | 08 | cały scenariusz `CreateOrder` |
| Regression Test | 08 | pakiet testów przed wdrożeniem `HAPPYHOURS50` |
| UI Automation | 08 | ten sam scenariusz przez interfejs Blazor |

## Struktura

```
TestingCourse
├── 01_Fundamentals
├── 02_TestDesign
│   ├── PathBasedTesting
│   │   └── Reservations
│   ├── BoundaryTesting
│   │   └── TemperatureMonitoring
│   └── StateBasedTesting
│       └── CoolingSystem
├── 03_TDD
│   ├── RedGreenRefactor
│   │   └── LoyaltyPoints
│   └── DiscountSystem
├── 04_Testability
│   ├── TestingTime
│   │   └── CouponExpiration
│   ├── Randomness
│   │   └── ShortUrlGenerator
│   ├── FileSystem
│   │   ├── IndustrialCamera
│   │   └── ProductCatalog
│   └── ExternalServices
│       └── CurrencyRateService
├── 05_TestDoubles
│   ├── Dummy
│   │   └── CreateOrder
│   ├── Stub
│   │   └── ProductCatalog
│   ├── Fake
│   │   └── CreateOrder
│   ├── Spy
│   │   └── CreateOrder
│   └── Mock
│       └── CreateOrder
├── 06_RefactoringWithTests
│   ├── CustomerRegistration
│   ├── FreeShipping
│   ├── DiscountSystem
│   ├── EmailProcessing
│   ├── ProductCatalog
│   ├── ProductPricing
│   ├── BreakTimer
│   ├── BomProcessing
│   └── LegacyPrinter
├── 07_IntegrationTesting
│   ├── DatabaseIntegration
│   │   ├── ProductCatalog
│   │   └── ProductCatalog.Testcontainers
│   ├── HttpIntegration
│   │   └── CurrencyRateService
│   └── RedisIntegration
│       ├── DiscountCache
│       └── DiscountCache.Testcontainers
└── 08_FunctionalTesting
    ├── RegressionTesting
    │   └── DiscountSystem
    ├── EndToEndTesting
    │   └── CreateOrder
    └── UIAutomation
        └── CreateOrder
```

## 01_Fundamentals

**Pytanie:** Jak napisać test?

**Techniki:**

- AAA
- Theory
- Exception
- Event
- Equality

| Projekt | Technika | Cel |
|---------|----------|-----|
| TestNaming | — | Jak nazwać test? |
| ArrangeActAssert | AAA | Jak zbudować test? |
| ParameterizedTests | Theory | Jak testować wiele przypadków? |
| TestingExceptions | Exception | Jak testować wyjątki? |
| TestingVoidMethods | AAA | Jak testować metody `void`? |
| TestingEvents | Event | Jak testować zdarzenia? |
| ObjectEquality | Equality | Jak testować równość obiektów? |

## 02_TestDesign

**Pytanie:** Jak znaleźć przypadki testowe?

**Techniki:**

- Paths
- Boundary Testing
- State Testing

| Projekt | Technika | Cel |
|---------|----------|-----|
| Reservations | Paths | Jak znaleźć przypadki testowe? |
| TemperatureMonitoring | Boundary Testing | Jak testować wartości graniczne? |
| CoolingSystem | State Testing | Jak testować systemy ze stanem? |

## 03_TDD

**Pytanie:** Jak budować kod metodą TDD?

**Techniki:**

- Red
- Green
- Refactor

| Projekt | Technika | Cel |
|---------|----------|-----|
| LoyaltyPoints | Red → Green → Refactor | Jak rozwijać kod w cyklu Red → Green → Refactor? |
| DiscountSystem | TDD | Jak rozwijać kod w cyklu Red → Green → Refactor? |

## 04_Testability

**Pytanie:** Jak rozpoznać kod trudny do testowania?

**Techniki:**

- Time Abstraction
- Randomness Abstraction
- File Write Abstraction
- File Read Abstraction
- External Service Abstraction

| Projekt | Technika | Cel |
|---------|----------|-----|
| CouponExpiration | Time Abstraction | Jak przetestować kupon ważny jutro? |
| ShortUrlGenerator | Randomness Abstraction | Jak testować kod zależny od losowości? |
| IndustrialCamera | File Write Abstraction | Jak testować kod zapisujący pliki? |
| ProductCatalog | File Read Abstraction | Jak testować kod odczytujący pliki? |
| CurrencyRateService | External Service Abstraction | Jak testować kod wywołujący usługi zewnętrzne? |

## 05_TestDoubles

**Pytanie:** Jak zastępować zależności w testach?

**Techniki:**

- Dummy
- Stub
- Fake
- Spy
- Mock

| Projekt | Technika | Cel |
|---------|----------|-----|
| CreateOrder | Dummy | Kiedy zależność nie jest używana? |
| ProductCatalog | Stub | Jak zwracać przygotowane dane? |
| CreateOrder | Fake | Jak zastąpić zależność prostą implementacją? |
| CreateOrder | Spy | Jak rejestrować wywołania? |
| CreateOrder | Mock | Jak weryfikować interakcje? |

## 06_RefactoringWithTests

**Pytanie:** Jak refaktoryzować kod pod osłoną testów?

**Techniki:**

- Composite
- Specification
- Strategy
- Chain of Responsibility
- Proxy
- Decorator
- State
- Visitor
- Adapter

**Ból → wzorzec:**

| Problem | Wzorzec |
|---------|---------|
| Rosnąca liczba reguł | Composite |
| Coraz bardziej złożone warunki biznesowe | Specification |
| Różne algorytmy realizujące ten sam cel | Strategy |
| Proces składający się z wielu kroków | Chain of Responsibility |
| Potrzeba cache lub kontroli dostępu | Proxy |
| Nakładanie dodatkowych zachowań | Decorator |
| Logika zależna od stanu obiektu | State |
| Nowe operacje na tej samej strukturze danych | Visitor |
| Niezgodne interfejsy | Adapter |

| Projekt | Problem | Wzorzec |
|---------|---------|---------|
| CustomerRegistration | Coraz więcej niezależnych reguł walidacyjnych klienta | Composite |
| FreeShipping | Złożone kryteria kwalifikacji do darmowej dostawy | Specification |
| DiscountSystem | Różne typy rabatów: procentowy, kwotowy, Happy Hours, weekendowy | Strategy |
| EmailProcessing | Wieloetapowe przetwarzanie wiadomości e-mail | Chain of Responsibility |
| ProductCatalog | Ograniczenie liczby odczytów z bazy danych poprzez cache | Proxy |
| ProductPricing | Nakładanie wielu promocji i rabatów na cenę produktu | Decorator |
| BreakTimer | Zachowanie systemu zależne od aktualnego stanu timera | State |
| BomProcessing | Dodawanie nowych operacji na niezmiennej strukturze BOM | Visitor |
| LegacyPrinter | Integracja nowego kodu ze starym, niekompatybilnym API | Adapter |

## 07_IntegrationTesting

**Pytanie:** Jak testować współpracę komponentów?

**Techniki:**

- Database Integration
- HTTP Integration
- Redis Integration
- Testcontainers

| Projekt | Technika | Cel |
|---------|----------|-----|
| ProductCatalog | Database Integration | Jak testować współpracę z bazą danych? |
| ProductCatalog.Testcontainers | Testcontainers | Jak uruchomić prawdziwą bazę danych w kontenerze Docker? |
| CurrencyRateService | HTTP Integration | Jak testować współpracę z API HTTP? |
| DiscountCache | Redis Integration | Jak testować współpracę z Redis? |
| DiscountCache.Testcontainers | Testcontainers | Jak uruchomić prawdziwy Redis w kontenerze Docker? |

## 08_FunctionalTesting

**Pytanie:** Jak testować proces biznesowy?

**Techniki:**

- Regression Testing
- End-to-End Testing
- UI Automation

| Projekt | Technika | Cel |
|---------|----------|-----|
| DiscountSystem | Regression Testing | Czy nowa zmiana nie zepsuła istniejących funkcji? |
| CreateOrder | End-to-End Testing | Czy cały proces biznesowy działa? |
| CreateOrder | UI Automation | Czy klient może zrealizować proces przez interfejs użytkownika? |

**Ten sam proces biznesowy — dwa poziomy testów:**

```
EndToEndTesting                    UIAutomation
        ↓                                  ↓
wywołuje CreateOrderUseCase      steruje aplikacją Blazor jak użytkownik
        ↓                                  ↓
prawdziwe repozytoria SQLite     otwórz sklep → koszyk → formularz → potwierdzenie
```
