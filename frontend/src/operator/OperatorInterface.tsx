import "./OperatorInterface.css"
import { CockpitPanel } from "./panels/CockpitPanel"
import { StatusPanel } from "./panels/StatusPanel"
import { stopRuntime } from "../api/runtimeApi";

export function OperatorInterface() {
    return (

        <div className="operator-page">
            <header className="operator-header">
                <div className="operator-brand">
                    <h1>iBUSIM</h1>
                    <p>Cockpit Integration &amp; Operator Console</p>
                </div>

                <div className="operator-header-actions">
                    <button
                        id="operator-stop-button"
                        onClick={stopRuntime}
                    >
                        Stop
                    </button>
                </div>
            </header>

            <main className="operator-main">
                <section className="operator-page-heading">
                    <h1>Operator Interface</h1>
                </section>

                <div className="operator-layout">
                    <section className="operator-status">
                        <StatusPanel />
                    </section>

                    <section className="operator-cockpit">
                        <CockpitPanel />
                    </section>
                </div>
            </main>
        </div>
    )
}

export default OperatorInterface